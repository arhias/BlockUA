using Core;
using Core.Interfaces;
using Core.Sevices;

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
    var hasher = cs.GetService<PasswordHasher>();
    return new CoinService(context, hasher);
});

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