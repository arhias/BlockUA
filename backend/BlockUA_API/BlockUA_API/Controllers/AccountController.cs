using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockUA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string? avatarUrl = null)
        {
            Core.Models.Response response = await accountService.Register(username, email, avatarUrl, password);
            return response.Code switch
            {
                200 => Ok(response.Data),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
        
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(string usernameOrEmail, string password)
        {
            Core.Models.Response response = await accountService.Login(usernameOrEmail, password);
            return response.Code switch
            {
                200 => Ok(response.Data),
                403 => BadRequest(response.AdditionalMessage),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
        
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(string userId, string? avatarUrl = null, string? username = null, string? email = null)
        {
            Core.Models.Response response = await accountService.UpdateUserInfo(userId, avatarUrl, username, email);
            return response.Code switch
            {
                200 => Ok(response.Data),
                400 => BadRequest(response.AdditionalMessage),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
        
        [Route("user")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(string userId)
        {
            Core.Models.Response response = await accountService.GetUserById(userId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
        
        [Route("users")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            Core.Models.Response response = await accountService.GetUsers();
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
        
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserData(string userId)
        {
            Core.Models.Response response = await accountService.DeleteUserData(userId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
        
        [Route("is-admin")]
        [HttpGet]
        public async Task<IActionResult> IsAdmin(string userId)
        {
            Core.Models.Response response = await accountService.IsAdmin(userId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
    }
}
