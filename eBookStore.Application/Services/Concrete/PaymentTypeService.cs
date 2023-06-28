using AutoMapper;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class PaymentTypeService:IPaymentTypeService
{
    private readonly IPaymentTypeRepository _paymentTypeRepository;
    private readonly IMapper _mapper;

    public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
    {
        _paymentTypeRepository = paymentTypeRepository;
        _mapper = mapper;
    }

    public bool ActivatePaymentType(int paymentTypeId)
    {
        var paymentType = _paymentTypeRepository.GetById(paymentTypeId);
        if (paymentType != null && paymentType.EntityStatus != EntityStatus.Active)
        {
            _paymentTypeRepository.Activate(paymentType);
            return true;
        }
        return false;
    }

    public void CreatePaymentType(CreatePaymentTypeDTO createPaymentTypeDTO)
    {
        var paymentType = _mapper.Map<PaymentType>(createPaymentTypeDTO);
        _paymentTypeRepository.Add(paymentType);
    }

    public void CreatePaymentTypes(List<CreatePaymentTypeDTO> createPaymentTypeDTOs)
    {
        foreach (var paymentTypeDTO in createPaymentTypeDTOs)
        {
            var paymentType = _mapper.Map<PaymentType>(paymentTypeDTO);
            _paymentTypeRepository.Add(paymentType);
        }
    }

    public bool DeactivatePaymentType(int paymentTypeId)
    {
        var paymentType = _paymentTypeRepository.GetById(paymentTypeId);
        if (paymentType != null && paymentType.EntityStatus != EntityStatus.Deactive)
        {
            _paymentTypeRepository.Deactivate(paymentType);
            return true;
        }
        return false;
    }

    public bool DeletePaymentType(int paymentTypeId)
    {
        var paymentType = _paymentTypeRepository.GetById(paymentTypeId);

        if (paymentType != null)
        {
            _paymentTypeRepository.Remove(paymentType);
            return true;
        }
        return false;
    }

    public bool DeletePaymentTypes(List<int> paymentTypes)
    {
        var paymentTypesToDelete = _paymentTypeRepository.GetAll()
                .Where(x => paymentTypes.Contains(x.Id)).ToList();

        if (paymentTypesToDelete != null && paymentTypesToDelete.Count > 0)
        {
            _paymentTypeRepository.RemoveRange(paymentTypesToDelete);
            return true;
        }
        return false;
    }

    public GetPaymentTypeDTO GetPaymentTypeById(int paymentTypeId)
    {
        var paymentType = _paymentTypeRepository.GetById(paymentTypeId);
        return _mapper.Map<GetPaymentTypeDTO>(paymentType);
    }

    public List<GetPaymentTypeDTO> GetPaymentTypes()
    {
        var paymentTypes = _paymentTypeRepository.GetAll();
        return _mapper.Map<List<GetPaymentTypeDTO>>(paymentTypes);
    }

    public bool UpdatePaymentType(UpdatePaymentTypeDTO updatePaymentTypeDTO)
    {
        var paymentType = _paymentTypeRepository.GetById(updatePaymentTypeDTO.Id);
        if (paymentType != null && paymentType.EntityStatus != EntityStatus.Deactive)
        {
            paymentType.Value = updatePaymentTypeDTO.Value;
            _paymentTypeRepository.Update(paymentType);
            return true;
        }
        return false;
    }

    public bool UpdatePaymentTypes(List<UpdatePaymentTypeDTO> updatePaymentTypeDTOs)
    {
        List<PaymentType> paymentTypesToUpdate = new List<PaymentType>();

        foreach (var paymentTypeDTO in updatePaymentTypeDTOs)
        {
            var paymentType = _paymentTypeRepository.GetById(paymentTypeDTO.Id);
            if (paymentType != null)
            {
                paymentType.Value = paymentTypeDTO.Value;
                paymentTypesToUpdate.Add(paymentType);
            }
        }
        if (paymentTypesToUpdate.Count > 0)
        {
            _paymentTypeRepository.UpdateRange(paymentTypesToUpdate);
            return true;
        }
        return false;
    }
}
