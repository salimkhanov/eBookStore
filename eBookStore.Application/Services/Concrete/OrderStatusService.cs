using AutoMapper;
using eBookStore.Application.DTOs.OrderStatus;
using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShippingMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class OrderStatusService:IOrderStatusService
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }

    public bool ActivateOrderStatus(int orderStatusId)
    {
        var orderStatus = _orderStatusRepository.GetById(orderStatusId);
        if (orderStatus != null && orderStatus.EntityStatus != EntityStatus.Active)
        {
            _orderStatusRepository.Activate(orderStatus);
            return true;
        }
        return false;
    }

    public void CreateOrderStatus(CreateOrderStatusDTO createOrderStatusDTO)
    {
        var orderStatus = _mapper.Map<OrderStatus>(createOrderStatusDTO);
        _orderStatusRepository.Add(orderStatus);
    }

    public void CreateOrderStatusRange(List<CreateOrderStatusDTO> createOrderStatusDTOs)
    {
        foreach (var orderStatusDTO in createOrderStatusDTOs)
        {
            var orderStatus = _mapper.Map<OrderStatus>(orderStatusDTO);
            _orderStatusRepository.Add(orderStatus);
        }
    }

    public bool DeactivateOrderStatus(int orderStatusId)
    {
        var orderStatus = _orderStatusRepository.GetById(orderStatusId);
        if (orderStatus != null && orderStatus.EntityStatus != EntityStatus.Deactive)
        {
            _orderStatusRepository.Deactivate(orderStatus);
            return true;
        }
        return false;
    }

    public bool DeleteOrderStatus(int orderStatusId)
    {
        var orderStatus = _orderStatusRepository.GetById(orderStatusId);

        if (orderStatus != null)
        {
            _orderStatusRepository.Remove(orderStatus);
            return true;
        }
        return false;
    }

    public bool DeleteOrderStatusRange(List<int> orderStatusRange)
    {
        var OrderStatusToDelete = _orderStatusRepository.GetAll()
                .Where(x => orderStatusRange.Contains(x.Id)).ToList();

        if (OrderStatusToDelete != null && OrderStatusToDelete.Count > 0)
        {
            _orderStatusRepository.RemoveRange(OrderStatusToDelete);
            return true;
        }
        return false;
    }

    public List<GetOrderStatusDTO> GetAllOrderStatus()
    {
        var orderStatusAll = _orderStatusRepository.GetAll();
        return _mapper.Map<List<GetOrderStatusDTO>>(orderStatusAll);
    }

    public GetOrderStatusDTO GetOrderStatusById(int orderStatusId)
    {
        var orderStatus = _orderStatusRepository.GetById(orderStatusId);
        return _mapper.Map<GetOrderStatusDTO>(orderStatus);
    }

    public bool UpdateOrderStatus(UpdateOrderStatusDTO updateOrderStatusDTO)
    {
        var orderStatus = _orderStatusRepository.GetById(updateOrderStatusDTO.Id);
        if (orderStatus != null && orderStatus.EntityStatus != EntityStatus.Deactive)
        {
            orderStatus.Status = updateOrderStatusDTO.Status;
            _orderStatusRepository.Update(orderStatus);
            return true;
        }
        return false;
    }

    public bool UpdateOrderStatusRange(List<UpdateOrderStatusDTO> updateOrderStatusDTOs)
    {
        List<OrderStatus> orderStatusToUpdate = new List<OrderStatus>();

        foreach (var orderStatusDTO in updateOrderStatusDTOs)
        {
            var orderStatus = _orderStatusRepository.GetById(orderStatusDTO.Id);
            if (orderStatus != null)
            {
                orderStatus.Status = orderStatusDTO.Status;
                orderStatusToUpdate.Add(orderStatus);
            }
        }
        if (orderStatusToUpdate.Count > 0)
        {
            _orderStatusRepository.UpdateRange(orderStatusToUpdate);
            return true;
        }
        return false;
    }
}
