using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class OrderLineRepository : BaseRepository<OrderLine>, IOrderLineRepository
{
}
