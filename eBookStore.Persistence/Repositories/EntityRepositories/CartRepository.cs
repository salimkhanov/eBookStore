using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public async Task<Cart> GetCartByUserIdAsync(int userId)
    {
        return await _dbContext.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }
}
