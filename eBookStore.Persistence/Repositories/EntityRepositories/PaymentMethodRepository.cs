using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Persistence.Repositories.EntityRepositories;

public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
{
}
