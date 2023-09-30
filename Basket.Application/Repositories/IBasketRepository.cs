using Basket.Core.Entities;

namespace Basket.Application.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string username);
        Task<ShoppingCart> UpdateBasket(ShoppingCart item);
        Task<ShoppingCart> DeleteBasket(string username);
    }
}
