using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using System.Security.Claims;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_loginService.GetUsreId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SAveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUsreId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki Değişiklikler Kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            await _basketService.DeleteBasket(_loginService.GetUsreId);
            return Ok("Sepet Başarıyla Silindi");
        }

    }
}
