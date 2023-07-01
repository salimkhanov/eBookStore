using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShippingMethod;

namespace eBookStore.Application.Services.Abstract;

public interface IShippingMethodService
{
    List<GetShippingMethodDTO> GetShippingMethods();
    GetShippingMethodDTO GetShippingMethodById(int shippingMethodId);
    void CreateShippingMethod(CreateShippingMethodDTO createShippingMethodDTO);
    bool UpdateShippingMethod(UpdateShippingMethodDTO updateShippingMethodDTO);
    bool DeleteShippingMethod(int shippingMethodId);
    bool DeactivateShippingMethod(int shippingMethodId);
    bool ActivateShippingMethod(int shippingMethodId);
    void CreateShippingMethods(List<CreateShippingMethodDTO> createShippingMethodDTOs);
    bool DeleteShippingMethods(List<int> shippingMethods);
    bool UpdateShippingMethods(List<UpdateShippingMethodDTO> updateShippingMethodDTOs);
}
