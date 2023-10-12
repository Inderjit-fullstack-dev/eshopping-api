using Basket.Application.Repositories;
using Basket.Core.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _cache.GetStringAsync(username);
            
            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            await _cache.SetStringAsync(shoppingCart.Username, JsonConvert.SerializeObject(shoppingCart));
            return await GetBasket(shoppingCart.Username);
        }

        public async Task<ShoppingCart> DeleteBasket(string username)
        {
            await _cache.RemoveAsync(username);
            return await GetBasket(username);
        }
    }
}
