using System.Text;
using Core;
using Core.Interfaces;
using Core.Models;
using Core.Sevices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddSingleton(db =>
{
    var connectionString = builder.Configuration["ConnectionString:String"];
    var databaseName = builder.Configuration["ConnectionString:Db"];
    return new BlockUaDbContext(connectionString, databaseName);
});

builder.Services.AddSingleton<PasswordHasher>();

builder.Services.AddSingleton<ICoinService, CoinService>(cs =>
{
    var context = cs.GetService<BlockUaDbContext>();
    return new CoinService(context);
});

builder.Services.AddSingleton<IJwtService>(sp =>
{
    var jwtOptions = sp.GetRequiredService<IOptions<JwtOptions>>().Value;
    return new JwtService(jwtOptions);
});
builder.Services.AddSingleton<JwtService>(sp => (JwtService)sp.GetRequiredService<IJwtService>());

builder.Services.AddSingleton<IAccountService, AccountService>(cs =>
{
    var context = cs.GetService<BlockUaDbContext>();
    var hasher = cs.GetService<PasswordHasher>();
    var jwt = cs.GetService<JwtService>();
    return new AccountService(context, hasher, jwt);
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = false
        };
    });


builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();