using System.Security.Claims;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockUA_API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController(ICoinService coinService) : ControllerBase
    {
        [Route("coin")]
        [HttpPost]
        public async Task<IActionResult> CreateCoin(string name)
        {
            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // if (string.IsNullOrEmpty(userId)) return Unauthorized();
            await coinService.CreateCoin(name);
            return Ok();
        }

        [Route("coin")]
        [HttpGet]
        public async Task<IActionResult> GetCoin(string coinId)
        {
            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // if (string.IsNullOrEmpty(userId)) return Unauthorized();
            Core.Models.Response response = await coinService.GetCoinInfo(coinId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(),
                _ => BadRequest("Something went wrong")
            };
        }

        [Route("coin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCoin(string coinId)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(userId)) return Unauthorized();
            // тут буде перевірка на адміна
            Core.Models.Response response = await coinService.DeleteCoin(coinId);
            return response.Code switch
            {
                200 => Ok(),
                404 => NotFound(),
                _ => BadRequest("Something went wrong")
            };
        }

        [Route("coin/total-cost")]
        [HttpGet]
        public async Task<IActionResult> GetTotalCoinCost(string coinId)
        {
            double dollar = 40;
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(userId)) return Unauthorized();
            Core.Models.Response totalCost = await coinService.GetTotalCount(coinId);
            if (totalCost.Code != 200) return NotFound();
            var cost = await coinService.GetCoinCost(coinId);
            if (totalCost.Code != 200) return NotFound();
            double result = (double)cost.Data * (double)totalCost.Data * dollar;
            return Ok(result);
        }

        [Route("coin/total-count")]
        [HttpGet]
        public async Task<IActionResult> GetTotalCoinCount(string coinId)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(userId)) return Unauthorized();
            var response = await coinService.GetTotalCount(coinId);
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(),
                _ => BadRequest("Something went wrong")
            };
        }

        [Route("coin/total")]
        [HttpGet]
        public async Task<IActionResult> GetAllCoins()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(userId)) return Unauthorized();
            var response = await coinService.GetCoins();
            return response.Code switch
            {
                200 => Ok(response.Data),
                404 => NotFound(),
                _ => BadRequest("Something went wrong")
            };
        }
    }
}
