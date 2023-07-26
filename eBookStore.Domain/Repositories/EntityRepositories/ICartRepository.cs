using eBookStore.Domain.Entities;

namespace eBookStore.Domain.Repositories.EntityRepositories;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> GetCartByUserIdAsync(int userId);
}
