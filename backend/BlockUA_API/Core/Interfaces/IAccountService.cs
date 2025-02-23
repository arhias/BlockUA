using Core.Models;

namespace Core.Interfaces;

public interface IAccountService
{
    Task<Response> Register(string username, string email, string password);
    Task<Response> Login(string usernameOrEmail, string password);
    Task<Response> UpdateUserInfo(string userId, string? avatarUrl = null, string? username = null, string? fullName = null, string? email = null);
    Task<Response> GetUserById();
    Task<Response> GetUser();
}