using eBookStore.Domain.Entities;

namespace eBookStore.Application.DTOs.Order;

public record OrderCreateDTO(
    int PaymentMethodId,
    int AddressId,
    int ShippingMethodId);