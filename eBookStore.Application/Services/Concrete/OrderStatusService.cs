using AutoMapper;
using eBookStore.Application.DTOs.OrderStatus;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class OrderStatusService : IOrderStatusService
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public OrderStatusService(
        IOrderStatusRepository orderStatusRepository,
        IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }

    public async Task CreateOrderStatus(OrderStatusDTO orderStatusDTO)
    {
        var status = _mapper.Map<OrderStatus>(orderStatusDTO);
        await _orderStatusRepository.AddAsync(status);
    }

    public async Task<bool> DeleteOrderStatusAsync(int id)
    {
        var orderStatus = await _orderStatusRepository.GetByIdAsync(id);
        if (orderStatus != null)
        {
            await _orderStatusRepository.RemoveAsync(orderStatus);
            return true;
        }
        return false;
    }

    public async Task<bool> OrderStatusExistsAsync(string status)
    {
        var orderStatus = (await _orderStatusRepository.FindAsync(a => a.Status.Trim().ToLower() == status.Trim().ToLower())).FirstOrDefault();
        return orderStatus != null;
    }

    public async Task<OrderStatusDTO> GetOrderStatusByIdAsync(int id)
    {
        var orderStatus = await _orderStatusRepository.GetByIdAsync(id);
        return _mapper.Map<OrderStatusDTO>(orderStatus);
    }

    public async Task<List<OrderStatusDTO>> GetOrderStatusesAsync()
    {
        var orderStatuses = await _orderStatusRepository.GetAllAsync();
        return _mapper.Map<List<OrderStatusDTO>>(orderStatuses);
    }

    public async Task<bool> UpdateOrderStatusAsync(OrderStatusDTO orderStatusDTO)
    {
        var orderStatus = await _orderStatusRepository.GetByIdAsync(orderStatusDTO.Id);
        if (orderStatus != null)
        {
            _mapper.Map(orderStatusDTO, orderStatus);
            await _orderStatusRepository.UpdateAsync(orderStatus);
            return true;
        }
        return false;
    }
}

