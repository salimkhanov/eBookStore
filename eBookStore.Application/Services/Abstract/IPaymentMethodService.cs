using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.PaymentMethod;

namespace eBookStore.Application.Services.Abstract;

public interface IPaymentMethodService
{
    Task<List<PaymentMethodResponseDTO>> GetPaymentMethodsAsync();
    Task<PaymentMethodResponseDTO> GetPaymentMethodByIdAsync(int Id);
    Task<List<PaymentMethodResponseDTO>> GetUserPaymentMethodsAsync();
    Task CreatePaymentMethodAsync(PaymentMethodRequestDTO paymentMethodRequest);
    Task<bool> UpdatePaymentMethodAsync(PaymentMethodRequestDTO paymentMethodRequest);
    Task<bool> DeletePaymentMethodAsync(int Id);
    Task<bool> MakeAsDefaultAsync(int Id);
}
