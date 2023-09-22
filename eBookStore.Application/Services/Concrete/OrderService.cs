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
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        IUserService userService,
        IBookRepository bookRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _userService = userService;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task CreateOrder(OrderCreateDTO orderCreateDTO)
    {
        var userId = await _userService.GetCurrentUserIdAsync();
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        var cartItem = cart.CartItems.ToList();
        
        var books = new List<Book>();

        foreach(var item in cartItem)
        {
            books.Add(await _bookRepository.GetByIdAsync(item.BookId));
        }

        var order = new Order
        {
            UserId = userId,
            PaymentMethodId = orderCreateDTO.PaymentMethodId,
            AddressId = orderCreateDTO.AddressId,
            ShippingMethodId = orderCreateDTO.ShippingMethodId,
            OrderStatusId = 0,
            Books = books
        };
        await _orderRepository.AddAsync(order);
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
