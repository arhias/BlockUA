using Core.Models;

namespace Core.Interfaces;

public interface IAccountService
{
    Task<Response> Register(string username, string email, string? avatarUrl, string password);
    Task<Response> Login(string usernameOrEmail, string password);
    Task<Response> UpdateUserInfo(string userId, string? avatarUrl = null, string? username = null, string? email = null);
    Task<Response> GetUserById(string userId);
    Task<Response> GetUsers();
    Task<Response> DeleteUserData(string userId);
    Task<Response> IsAdmin(string userId);
}