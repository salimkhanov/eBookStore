using AutoMapper;
using eBookStore.Application.DTOs.PaymentMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public PaymentMethodService(
        IPaymentMethodRepository paymentMethodRepository,
        IUserService userService,
        IMapper mapper)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task CreatePaymentMethodAsync(PaymentMethodRequestDTO paymentMethodRequest)
    {
        var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodRequest);
        paymentMethod.UserId = await _userService.GetCurrentUserIdAsync();

        // First created payment is set as default
        paymentMethod.IsDefault = true;
        await _paymentMethodRepository.AddAsync(paymentMethod);
    }

    public async Task<bool> DeletePaymentMethodAsync(int Id)
    {
        var paymentMethod = await _paymentMethodRepository.GetByIdAsync(Id);
        if (paymentMethod != null)
        {
            await _paymentMethodRepository.RemoveAsync(paymentMethod);
            return true;
        }
        return false;
    }

    public async Task<PaymentMethodResponseDTO> GetPaymentMethodByIdAsync(int Id)
    {
        var paymentMethod = await _paymentMethodRepository.GetByIdAsync(Id);
        return _mapper.Map<PaymentMethodResponseDTO>(paymentMethod);
    }

    public async Task<List<PaymentMethodResponseDTO>> GetPaymentMethodsAsync()
    {
        var paymentMethods = await _paymentMethodRepository.GetAllAsync();
        return _mapper.Map<List<PaymentMethodResponseDTO>>(paymentMethods); 
    }

    public async Task<List<PaymentMethodResponseDTO>> GetUserPaymentMethodsAsync()
    {
        var user = await _userService.GetCurrentUserIdAsync();

        var paymentMethods = await _paymentMethodRepository
            .FindAsync(pm => pm.UserId == user);

        var paymentMethodDTOs = _mapper.Map<List<PaymentMethodResponseDTO>>(paymentMethods);
        return paymentMethodDTOs;
    }

    public async Task<bool> MakeAsDefaultAsync(int Id)
    {
        var paymentMethod = await _paymentMethodRepository.GetByIdAsync(Id);
        var user = await _userService.GetCurrentUserIdAsync();

        if (paymentMethod != null)
        {
            var defaultPaymentMethod = (await _paymentMethodRepository
                .FindAsync(pm => pm.IsDefault && pm.UserId == user))
                .FirstOrDefault();

            if (defaultPaymentMethod != null)
            {
                defaultPaymentMethod.IsDefault = false;
                paymentMethod.IsDefault = true;

                await _paymentMethodRepository.UpdateAsync(defaultPaymentMethod);
                await _paymentMethodRepository.UpdateAsync(paymentMethod);
                return true;
            }
        }

        return false;
    }

    public async Task<bool> UpdatePaymentMethodAsync(PaymentMethodRequestDTO paymentMethodRequest)
    {
        var paymentMethod = await _paymentMethodRepository.GetByIdAsync(paymentMethodRequest.Id);
        if (paymentMethod != null)
        {
            _mapper.Map(paymentMethodRequest, paymentMethod);
            await _paymentMethodRepository.UpdateAsync(paymentMethod);
            return true;
        }
        return false;
    }
}
