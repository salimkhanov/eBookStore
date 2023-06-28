using AutoMapper;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.UserPaymentMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Application.Services.Concrete;

public class UserPaymentMethodService:IUserPaymentMethodService
{
	private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;
    private readonly UserManager<User> _userManager;
    private readonly IPaymentTypeRepository _paymentTypeRepository;
	private readonly IMapper _mapper;
	public UserPaymentMethodService(IUserPaymentMethodRepository userPaymentMethodRepository,
		UserManager<User> userManager,
		IPaymentTypeRepository paymentTypeRepository,
		IMapper mapper)
	{
		_userPaymentMethodRepository = userPaymentMethodRepository;
		_userManager = userManager;
		_paymentTypeRepository = paymentTypeRepository;
		_mapper = mapper;
    }

    public bool ActivateUserPaymentMethod(int userPaymentMethodId)
    {
        var userPaymentMethod = _userPaymentMethodRepository.GetById(userPaymentMethodId);
        if (userPaymentMethod != null && userPaymentMethod.EntityStatus != EntityStatus.Active)
        {
            _userPaymentMethodRepository.Activate(userPaymentMethod);
            return true;
        }
        return false;
    }
    public async Task<bool> CreateUserPaymentMethod(CreateUserPaymentMethodDTO createUserPaymentMethodDTO)
    {
        var userId = await _userManager.FindByIdAsync(createUserPaymentMethodDTO.UserId.ToString());
        if (userId != null)
        {
            var paymentTypeId = _paymentTypeRepository.GetById(createUserPaymentMethodDTO.PaymentTypeId);
            if (paymentTypeId != null)
            {
                var userPaymentMethod = _mapper.Map<UserPaymentMethod>(createUserPaymentMethodDTO);
                _userPaymentMethodRepository.Add(userPaymentMethod);
                return true;
            }
            return false;
        }
        return false;
    }
    public bool CreateUserPaymentMethods(List<CreateUserPaymentMethodDTO> createUserPaymentMethodDTOs)
    {
        var userIds = createUserPaymentMethodDTOs.Select(dto => dto.UserId).ToList();
        var users = _userManager.Users.Where(user => userIds.Contains(user.Id)).ToList();

        var paymentTypeIds = createUserPaymentMethodDTOs.Select(dto => dto.PaymentTypeId).ToList();
        var paymentTypes = _paymentTypeRepository.GetAll().
            Where(paymentType => paymentTypeIds.Contains(paymentType.Id)).ToList();

        var userPaymentMethodToAdd = createUserPaymentMethodDTOs
            .Where(dto => users.Any(user => user.Id == dto.UserId) &&
            paymentTypes.Any(payment => payment.Id == dto.PaymentTypeId))
            .Select(dto => _mapper.Map<UserPaymentMethod>(dto))
            .ToList();

        if (userPaymentMethodToAdd.Count > 0)
        {
            _userPaymentMethodRepository.AddRange(userPaymentMethodToAdd);
            return true;
        }
        return false;
    }
    public bool DeactivateUserPaymentMethod(int userPaymentMethodId)
    {
        var userPaymentMethod = _userPaymentMethodRepository.GetById(userPaymentMethodId);
        if (userPaymentMethod != null && userPaymentMethod.EntityStatus != EntityStatus.Deactive)
        {
            _userPaymentMethodRepository.Deactivate(userPaymentMethod);
            return true;
        }
        return false;
    }
    public bool DeleteUserPaymentMethod(int userPaymentMethodId)
    {
        var userPaymentMethod = _userPaymentMethodRepository.GetById(userPaymentMethodId);

        if (userPaymentMethod != null)
        {
            _userPaymentMethodRepository.Remove(userPaymentMethod);
            return true;
        }
        return false;
    }
    public bool DeleteUserPaymentMethods(List<int> userPaymentMethods)
    {
        var userPaymentMethodsToDelete = _userPaymentMethodRepository.GetAll()
            .Where(x => userPaymentMethods.Contains(x.Id)).ToList();

        if (userPaymentMethodsToDelete != null && userPaymentMethodsToDelete.Count > 0)
        {
            _userPaymentMethodRepository.RemoveRange(userPaymentMethodsToDelete);
            return true;
        }
        return false;
    }
    public GetUserPaymentMethodDTO GetUserPaymentMethodById(int userPaymentMethodId)
    {
        var userPaymentMethod = _userPaymentMethodRepository.GetById(userPaymentMethodId);
        return _mapper.Map<GetUserPaymentMethodDTO>(userPaymentMethod);
    }
    public List<GetUserPaymentMethodDTO> GetUserPaymentMethods()
    {
        var userPaymentMethods = _userPaymentMethodRepository.GetAll();
        return _mapper.Map<List<GetUserPaymentMethodDTO>>(userPaymentMethods);
    }
    public async Task<bool> UpdateUserPaymentMethod(UpdateUserPaymentMethodDTO updateUserPaymentMethod)
    {
        var userId = await _userManager.FindByIdAsync(updateUserPaymentMethod.UserId.ToString());
        var paymentTypeId = _paymentTypeRepository.GetById(updateUserPaymentMethod.PaymentTypeId);

        if (userId != null && paymentTypeId != null)
        {
            var userPaymentMethod = _userPaymentMethodRepository.GetById(updateUserPaymentMethod.Id);
            if (userPaymentMethod != null && userPaymentMethod.EntityStatus != EntityStatus.Deactive)
            {
                userPaymentMethod.UserId = updateUserPaymentMethod.UserId;
                userPaymentMethod.PaymentTypeId = updateUserPaymentMethod.PaymentTypeId;
                userPaymentMethod.Provider = updateUserPaymentMethod.Provider;
                userPaymentMethod.AccountNumber = updateUserPaymentMethod.AccountNumber;
                userPaymentMethod.ExpiryDate = updateUserPaymentMethod.ExpiryDate;
                userPaymentMethod.IsDefault = updateUserPaymentMethod.IsDefault;
                _userPaymentMethodRepository.Update(userPaymentMethod);
                return true;
            }
            return false;
        }
        return false;
    }
    public async Task<bool> UpdateUserPaymentMethods(List<UpdateUserPaymentMethodDTO> updateUserPaymentMethods)
    {
        List<UserPaymentMethod> userPaymentMethodToUpdate = new List<UserPaymentMethod>();

        foreach (var userPaymentMethodDTO in updateUserPaymentMethods)
        {
            var userId = await _userManager.FindByIdAsync(userPaymentMethodDTO.UserId.ToString());
            var paymentTypeId = _paymentTypeRepository.GetById(userPaymentMethodDTO.PaymentTypeId);
            if (userId != null && paymentTypeId != null)
            {
                var userPaymentMethod = _userPaymentMethodRepository.GetById(userPaymentMethodDTO.Id);
                if (userPaymentMethod != null)
                {
                    userPaymentMethod.UserId = userPaymentMethodDTO.UserId;
                    userPaymentMethod.PaymentTypeId = userPaymentMethodDTO.PaymentTypeId;
                    userPaymentMethod.Provider = userPaymentMethodDTO.Provider;
                    userPaymentMethod.AccountNumber = userPaymentMethodDTO.AccountNumber;
                    userPaymentMethod.ExpiryDate = userPaymentMethodDTO.ExpiryDate;
                    userPaymentMethod.IsDefault = userPaymentMethodDTO.IsDefault;
                    userPaymentMethodToUpdate.Add(userPaymentMethod);
                }
            }
        }
        if (userPaymentMethodToUpdate.Count > 0)
        {
            _userPaymentMethodRepository.UpdateRange(userPaymentMethodToUpdate);
            return true;
        }
        return false;
    }
}
