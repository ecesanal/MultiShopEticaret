using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDisCountCouponDto>> GetAllDisCountCouponAsync();
        Task CreateDisCountCouponAsync(CreateDisCountCouponDto createCouponDto);
        Task UpdateDisCountCouponAsync(UpdateDisCountCouponDto updateCouponDto);
        Task DeleteDisCountCouponAsync(int id);
        Task<GetByIdDisCountCouponDto> GetByIdDisCountCouponAsync(int id);
    }
}
