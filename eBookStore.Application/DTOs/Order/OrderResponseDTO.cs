using eBookStore.Application.DTOs.CartItem;

namespace eBookStore.Application.DTOs.Order;

public class OrderResponseDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string PaymentMethodName { get; set; }
    public string AddressLine { get; set; }
    public string ShippingMethodName { get; set; }
    public double OrderTotal { get; set; }
    public string OrderStatus { get; set; }
    public List<CartItemDTO> CartItems { get; set; }
}

