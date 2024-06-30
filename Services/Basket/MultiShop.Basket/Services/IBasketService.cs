using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
	public interface IBasketService
	{
		Task<BasketTotalDto> GetBAsket(string userId);
		Task SaveBAsket(BasketTotalDto basketTotalDto);
		Task DeleteBAsket(string userId);

	}
}
