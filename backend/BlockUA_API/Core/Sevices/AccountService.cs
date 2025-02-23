using Core.Interfaces;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Sevices;

public class AccountService(BlockUaDbContext context, PasswordHasher hasher, JwtService jwtService) : IAccountService
{
    public async Task<Response> Register(string username, string email, string? avatarUrl, string password)
    {
        User user = new User(username, email, avatarUrl, hasher.HashPassword(password));
        await context.Users.InsertOneAsync(user);
        Wallet wallet = new Wallet(user.Id);
        await context.Wallets.InsertOneAsync(wallet);
        return new Response(200, "Successfully");
    }

    public async Task<Response> Login(string usernameOrEmail, string password)
    {
        var result = await IsValidUser(password, usernameOrEmail);

        if (result.Code == 403)
            return result;

        if (result.Data is not User user)
            return new Response(404, "User does not exist.");

        var claims = jwtService.GetClaims(user);
        var token = jwtService.CreateToken(claims);

        var existingUser = await context.Users
                               .Find(u =>
                                   u.Username.Equals(usernameOrEmail,
                                       StringComparison.CurrentCultureIgnoreCase)).FirstOrDefaultAsync() ??
                           await context.Users.Find(u =>
                                   u.Email.Equals(usernameOrEmail, StringComparison.CurrentCultureIgnoreCase))
                               .FirstOrDefaultAsync();
        return existingUser switch
        {
            null => new Response(404, "Username not found"),
            _ => new Response(200, "Login success", token)
        };
    }

    public async Task<Response> UpdateUserInfo(string userId, string? avatarUrl = null, string? username = null,
        string? email = null)
    {
        var user = await context.Users.Find(u => u.Id.ToString().Equals(userId)).FirstOrDefaultAsync();
        if (user == null) return new Response(404, "User not found");
        if (avatarUrl != null)
        {
            if (avatarUrl != "") user.AvatarUrl = avatarUrl;
            else return new Response(400, "Invalid avatar url");
        }

        if (username != null)
        {
            if (username != "") user.Username = username;
            else return new Response(400, "Invalid username");
        }

        if (email != null)
        {
            if (email != "") user.Email = email;
            else return new Response(400, "Invalid email");
        }

        await context.Users.ReplaceOneAsync(u => u.Id.Equals(user.Id), user);
        return new Response(200, "Successfully");
    }

    public async Task<Response> GetUserById(string userId)
    {
        var user = await context.Users.Find(u => u.Id.ToString().Equals(userId)).FirstOrDefaultAsync();
        return user switch
        {
            null => new Response(404, "User not found"),
            _ => new Response(200, "Successfully", user.ToDtoString())
        };
    }

    public async Task<Response> GetUsers()
    {
        var users =  await context.Users.Find(new BsonDocument()).ToListAsync();
        return users switch
        {
            null => new Response(404, "Users not found"),
            _ => new Response(200, "Successfully", users.Select(u => u.ToDtoString()))
        };
    }

    public async Task<Response> DeleteUserData(string userId)
    {
        var user = await context.Users.Find(u => u.Id.ToString().Equals(userId)).FirstOrDefaultAsync();
        if (user == null) return new Response(404, "User not found");
        await context.Users.DeleteOneAsync(u => u.Id.Equals(user.Id));
        var wallet = await context.Wallets.Find(w => w.UserId.Equals(user.Id)).FirstOrDefaultAsync();
        if (wallet != null) await context.Wallets.DeleteOneAsync(w => w.UserId.Equals(user.Id));
        return new Response(200, "Successfully");
    }

    public async Task<Response> IsAdmin(string userId)
    {
        var user = await context.Users.Find(u => u.Id.ToString().Equals(userId)).FirstOrDefaultAsync();
        if (user == null) return new Response(404, "User not found");
        return user.Admin switch
        {
            false => new Response(200, "User is not an admin", false),
            true => new Response(200, "User is an admin", true)
        };
    }

    private async Task<Response> IsValidUser(string password, string usernameOrEmail)
    {
        User? user = null;
        user = await context.Users
                   .Find(u => u.Username.Equals(usernameOrEmail, StringComparison.CurrentCultureIgnoreCase))
                   .FirstOrDefaultAsync() ??
               await context.Users.Find(u => u.Email.Equals(usernameOrEmail, StringComparison.CurrentCultureIgnoreCase))
                   .FirstOrDefaultAsync();


        if (user == null) return new Response(404, "User not found.");

        return hasher.VerifyPassword(password, user.Password) switch {
            false => new Response(403, "Invalid username/email or password."),
            true => new Response(200, "User is valid.", user)
        };
    }
}