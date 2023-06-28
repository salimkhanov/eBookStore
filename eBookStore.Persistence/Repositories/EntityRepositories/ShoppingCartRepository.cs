using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class ShoppingCartRepository:BaseRepository<ShoppingCart>,IShoppingCartRepository
{
}
