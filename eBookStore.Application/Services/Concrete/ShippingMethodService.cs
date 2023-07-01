using AutoMapper;
using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShippingMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class ShippingMethodService:IShippingMethodService
{
    private readonly IShippingMethodRepository _shippingMethodRepository;
    private readonly IMapper _mapper;

    public ShippingMethodService(IShippingMethodRepository shippingMethodRepository, IMapper mapper)
    {
        _shippingMethodRepository = shippingMethodRepository;
        _mapper = mapper;
    }

    public bool ActivateShippingMethod(int shippingMethodId)
    {
        var shippingMethod = _shippingMethodRepository.GetById(shippingMethodId);
        if (shippingMethod != null && shippingMethod.EntityStatus != EntityStatus.Active)
        {
            _shippingMethodRepository.Activate(shippingMethod);
            return true;
        }
        return false;
    }

    public void CreateShippingMethod(CreateShippingMethodDTO createShippingMethodDTO)
    {
        var shippingMethod = _mapper.Map<ShippingMethod>(createShippingMethodDTO);
        _shippingMethodRepository.Add(shippingMethod);
    }

    public void CreateShippingMethods(List<CreateShippingMethodDTO> createShippingMethodDTOs)
    {
        foreach (var shippingMethodDTO in createShippingMethodDTOs)
        {
            var shippingMethod = _mapper.Map<ShippingMethod>(shippingMethodDTO);
            _shippingMethodRepository.Add(shippingMethod);
        }
    }

    public bool DeactivateShippingMethod(int shippingMethodId)
    {
        var shippingMethod = _shippingMethodRepository.GetById(shippingMethodId);
        if (shippingMethod != null && shippingMethod.EntityStatus != EntityStatus.Deactive)
        {
            _shippingMethodRepository.Deactivate(shippingMethod);
            return true;
        }
        return false;
    }

    public bool DeleteShippingMethod(int shippingMethodId)
    {
        var shippingMethod = _shippingMethodRepository.GetById(shippingMethodId);

        if (shippingMethod != null)
        {
            _shippingMethodRepository.Remove(shippingMethod);
            return true;
        }
        return false;
    }

    public bool DeleteShippingMethods(List<int> shippingMethods)
    {
        var shippingMethodsToDelete = _shippingMethodRepository.GetAll()
                .Where(x => shippingMethods.Contains(x.Id)).ToList();

        if (shippingMethodsToDelete != null && shippingMethodsToDelete.Count > 0)
        {
            _shippingMethodRepository.RemoveRange(shippingMethodsToDelete);
            return true;
        }
        return false;
    }

    public GetShippingMethodDTO GetShippingMethodById(int shippingMethodId)
    {
        var shippingMethod = _shippingMethodRepository.GetById(shippingMethodId);
        return _mapper.Map<GetShippingMethodDTO>(shippingMethod);
    }

    public List<GetShippingMethodDTO> GetShippingMethods()
    {
        var shippingMethods = _shippingMethodRepository.GetAll();
        return _mapper.Map<List<GetShippingMethodDTO>>(shippingMethods);
    }

    public bool UpdateShippingMethod(UpdateShippingMethodDTO updateShippingMethodDTO)
    {
        var shippingMethod = _shippingMethodRepository.GetById(updateShippingMethodDTO.Id);
        if (shippingMethod != null && shippingMethod.EntityStatus != EntityStatus.Deactive)
        {
            shippingMethod.Name = updateShippingMethodDTO.Name;
            shippingMethod.Price = updateShippingMethodDTO.Price;
            _shippingMethodRepository.Update(shippingMethod);
            return true;
        }
        return false;
    }

    public bool UpdateShippingMethods(List<UpdateShippingMethodDTO> updateShippingMethodDTOs)
    {
        List<ShippingMethod> shippingMethodsToUpdate = new List<ShippingMethod>();

        foreach (var shippingMethodDTO in updateShippingMethodDTOs)
        {
            var shippingMethod = _shippingMethodRepository.GetById(shippingMethodDTO.Id);
            if (shippingMethod != null)
            {
                shippingMethod.Name = shippingMethodDTO.Name;
                shippingMethod.Price = shippingMethodDTO.Price;
                shippingMethodsToUpdate.Add(shippingMethod);
            }
        }
        if (shippingMethodsToUpdate.Count > 0)
        {
            _shippingMethodRepository.UpdateRange(shippingMethodsToUpdate);
            return true;
        }
        return false;
    }
}
