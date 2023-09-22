using eBookStore.Domain.Entities;

namespace eBookStore.Domain.Repositories.EntityRepositories;

public interface ICartItemRepository : IBaseRepository<CartItem>
{
    Task ClearCartItemsAsync(int cartId);
    Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId);
}
