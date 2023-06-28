using eBookStore.Application.DTOs.PaymentType;
using eBookStore.Application.DTOs.ShoppingCart;

namespace eBookStore.Application.Services.Abstract;

public interface IPaymentTypeService
{
    List<GetPaymentTypeDTO> GetPaymentTypes();
    GetPaymentTypeDTO GetPaymentTypeById(int paymentTypeId);
    void CreatePaymentType(CreatePaymentTypeDTO createPaymentTypeDTO);
    bool UpdatePaymentType(UpdatePaymentTypeDTO updatePaymentTypeDTO);
    bool DeletePaymentType(int paymentTypeId);
    bool DeactivatePaymentType(int paymentTypeId);
    bool ActivatePaymentType(int paymentTypeId);
    void CreatePaymentTypes(List<CreatePaymentTypeDTO> createPaymentTypeDTOs);
    bool DeletePaymentTypes(List<int> paymentTypes);
    bool UpdatePaymentTypes(List<UpdatePaymentTypeDTO> updatePaymentTypeDTOs);
}
