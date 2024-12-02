using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> DisCountCouponList()
        {
            var values = await _discountService.GetAllDisCountCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisCountCouponById(int id)
        {
            var values= await _discountService.GetByIdDisCountCouponAsync(id); 
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDisCountCoupon(CreateDisCountCouponDto createCouponDto)
        {
            await _discountService.CreateDisCountCouponAsync(createCouponDto);
            return Ok("Kupon Başarıyla Oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDisCountCoupon(int id)
        {
            await _discountService.DeleteDisCountCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDisCountCoupon(UpdateDisCountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDisCountCouponAsync(updateCouponDto);
            return Ok("Kupon Başarıyla Güncellendi");
        }
    }
}
