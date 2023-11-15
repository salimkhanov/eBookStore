using AutoMapper;
using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.DTOs.Order;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IUserService _userService;
    private readonly IShippingMethodRepository _shippingMethodRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        IUserService userService,
        IShippingMethodRepository shippingMethodRepository,
        IOrderStatusRepository orderStatusRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _userService = userService;
        _shippingMethodRepository = shippingMethodRepository;
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }

    public async Task<bool> ChangeOrderStatus(int orderId, int statusId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        var status = await _orderStatusRepository.GetByIdAsync(statusId);

        if (order != null && status != null)
        {
            order.OrderStatus = status;
            //order.OrderStatusId = status.Id;
            await _orderRepository.UpdateAsync(order);
            return true;
        }

        return false;
    }

    public async Task CreateOrder(OrderCreateDTO orderCreateDTO)
    {
        var userId = await _userService.GetCurrentUserIdAsync();
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        var cartItems = cart.CartItems.ToList();

        double orderTotal = 0; 

        foreach (var cartItem in cartItems)
        {
            double subtotal = cartItem.Price * cartItem.Qty;

            if (cartItem.Book.Discount != null)
            {
                subtotal = subtotal - (subtotal * (cartItem.Book.Discount.DiscountRate / 100));
            }

            orderTotal += subtotal;
        }
        var shippingMethod = await _shippingMethodRepository.GetByIdAsync(orderCreateDTO.ShippingMethodId);

        orderTotal += shippingMethod.Price;

        var order = _mapper.Map<Order>(orderCreateDTO);

        // Order details
        order.UserId = userId;
        order.OrderDate = DateTime.UtcNow;
        order.OrderTotal = orderTotal;
        order.PaymentMethodId = orderCreateDTO.PaymentMethodId;
        order.AddressId = orderCreateDTO.AddressId;

        await _orderRepository.AddAsync(order);

        //clear
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order != null)
        {
            await _orderRepository.RemoveAsync(order);
            return true;
        }
        return false;
    }

    public async Task<List<OrderResponseDTO>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _orderRepository.FindAsync(o => o.UserId == userId);
        return _mapper.Map<List<OrderResponseDTO>>(orders);
    }

    public async Task<bool> UpdateOrderAsync(BookGenreDTO bookGenreDTO)
    {
        var order = await _orderRepository.GetByIdAsync(bookGenreDTO.Id);
        if (order != null)
        {
            _mapper.Map(bookGenreDTO, order);
            await _orderRepository.UpdateAsync(order);
            return true;
        }
        return false;
    }
}
