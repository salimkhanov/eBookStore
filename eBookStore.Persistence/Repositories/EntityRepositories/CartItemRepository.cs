using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public async Task ClearCartItemsAsync(int cartId)
    {
        var cartItemsToRemove = await _dbContext.CartItems.Where(ci => ci.CartId == cartId).ToListAsync();
        _dbContext.CartItems.RemoveRange(cartItemsToRemove);
        await _dbContext.SaveChangesAsync();
    }
}
