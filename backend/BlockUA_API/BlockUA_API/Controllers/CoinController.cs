using System.Security.Claims;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockUA_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController(ICoinService coinService, IAccountService accountService) : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("coin")]
        [HttpPost]
        public async Task<IActionResult> CreateCoin(string name)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            var isAdmin = await accountService.IsAdmin(userId);
            if (isAdmin.Code != 200) return BadRequest(isAdmin.AdditionalMessage);
            if (!(bool)isAdmin.Data) return StatusCode(StatusCodes.Status403Forbidden, "Access denied");
            await coinService.CreateCoin(name);
            return Ok();
        }

        [Route("coin")]
        [HttpGet]
        public async Task<IActionResult> GetCoin(string coinId)
        {
            Core.Models.Response response = await coinService.GetCoinInfo(coinId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }

        [Route("coin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCoin(string coinId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            var isAdmin = await accountService.IsAdmin(userId);
            if (isAdmin.Code != 200) return BadRequest(isAdmin.AdditionalMessage);
            if (!(bool)isAdmin.Data) return StatusCode(StatusCodes.Status403Forbidden, "Access denied");
            Core.Models.Response response = await coinService.DeleteCoin(coinId);
            return response.Code switch
            {
                200 => Ok(),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }

        // [Route("coin/total-cost")]
        // [HttpGet]
        // public async Task<IActionResult> GetTotalCoinCost(string coinId)
        // {
        //     double dollar = 40;
        //     Core.Models.Response totalCost = await coinService.GetTotalCount(coinId);
        //     if (totalCost.Code != 200) return NotFound(totalCost.AdditionalMessage);
        //     var cost = await coinService.GetCoinCost(coinId);
        //     if (totalCost.Code != 200) return NotFound(cost.AdditionalMessage);
        //     double result = (double)cost.Data * (double)totalCost.Data * dollar;
        //     return Ok(result);
        // }

        [Route("coin/total-count")]
        [HttpGet]
        public async Task<IActionResult> GetTotalCoinCount(string coinId)
        {
            var response = await coinService.GetTotalCount(coinId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("coin/total")]
        [HttpGet]
        public async Task<IActionResult> GetAllCoins()
        {
            var response = await coinService.GetCoins();
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }

        [Route("coin/exchange-rates")]
        [HttpGet]
        public async Task<IActionResult> GetCoinExchangeRates(string coinId)
        {
            var response = await coinService.GetExchangeRates(coinId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(response.AdditionalMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Internal server error")
            };
        }
    }
}
