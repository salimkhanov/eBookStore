using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
}
