using AutoMapper;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Application.Services.Concrete;

public class ShoppingCartService:IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,UserManager<User> userManager, IMapper mapper)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public bool ActivateShoppingCart(int shoppingCartId)
    {
        var shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
        if (shoppingCart != null && shoppingCart.EntityStatus != EntityStatus.Active)
        {
            _shoppingCartRepository.Activate(shoppingCart);
            return true;
        }
        return false;
    }

    public async Task<bool> CreateShoppingCart(CreateShoppingCartDTO createShoppingCartDTO)
    {
        var userId = await _userManager.FindByIdAsync(createShoppingCartDTO.UserId.ToString());
        if (userId != null)
        {
            var shoppingCart = _mapper.Map<ShoppingCart>(createShoppingCartDTO);
            _shoppingCartRepository.Add(shoppingCart);
            return true;
        }
        return false;
    }

    public bool CreateShoppingCarts(List<CreateShoppingCartDTO> createShoppingCartDTOs)
    {
        var userIds = createShoppingCartDTOs.Select(dto => dto.UserId).ToList();
        var users = _userManager.Users.Where(user => userIds.Contains(user.Id)).ToList();

        var shoppingCartsToAdd = createShoppingCartDTOs
            .Where(dto => users.Any(user => user.Id == dto.UserId))
            .Select(dto => _mapper.Map<ShoppingCart>(dto))
            .ToList();

        if (shoppingCartsToAdd.Count > 0)
        {
            _shoppingCartRepository.AddRange(shoppingCartsToAdd);
            return true;
        }
        return false;
    }

    public bool DeactivateShoppingCart(int shoppingCartId)
    {
        var shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
        if (shoppingCart != null && shoppingCart.EntityStatus != EntityStatus.Deactive)
        {
            _shoppingCartRepository.Deactivate(shoppingCart);
            return true;
        }
        return false;
    }

    public bool DeleteShoppingCart(int shoppingCartId)
    {
        var shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);

        if (shoppingCart != null)
        {
            _shoppingCartRepository.Remove(shoppingCart);
            return true;
        }
        return false;
    }

    public bool DeleteShoppingCarts(List<int> shoppingCarts)
    {
        var shoppingCartsToDelete = _shoppingCartRepository.GetAll()
            .Where(x => shoppingCarts.Contains(x.Id)).ToList();

        if (shoppingCartsToDelete != null && shoppingCartsToDelete.Count > 0)
        {
             _shoppingCartRepository.RemoveRange(shoppingCartsToDelete);
            return true;
        }
        return false;
    }

    public GetShoppingCartDTO GetShoppingCartById(int shoppingCartId)
    {
        var shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
        return _mapper.Map<GetShoppingCartDTO>(shoppingCart);
    }

    public List<GetShoppingCartDTO> GetShoppingCarts()
    {
        var shoppingCarts = _shoppingCartRepository.GetAll();
        return _mapper.Map<List<GetShoppingCartDTO>>(shoppingCarts);
    }

    public async Task<bool> UpdateShoppingCart(UpdateShoppingCartDTO updateShoppingCartDTO)
    {
        var userId = await _userManager.FindByIdAsync(updateShoppingCartDTO.UserId.ToString());

        if (userId != null)
        {
            var shoppingCart = _shoppingCartRepository.GetById(updateShoppingCartDTO.Id);
            if (shoppingCart != null && shoppingCart.EntityStatus != EntityStatus.Deactive)
            {
                shoppingCart.UserId = updateShoppingCartDTO.UserId;
                _shoppingCartRepository.Update(shoppingCart);
                return true;
            }
            return false;
        }
        return false;
    }

    public async Task<bool> UpdateShoppingCarts(List<UpdateShoppingCartDTO> updateShoppingCartDTOs)
    {
        List<ShoppingCart> shoppingCartToUpdate = new List<ShoppingCart>();

        foreach (var shoppingCartDTO in updateShoppingCartDTOs)
        {
            var userId = await _userManager.FindByIdAsync(shoppingCartDTO.UserId.ToString());
            if (userId != null)
            {
                var shoppingCart = _shoppingCartRepository.GetById(shoppingCartDTO.Id);
                if (shoppingCart != null)
                {
                    shoppingCart.UserId = shoppingCartDTO.UserId;
                    shoppingCartToUpdate.Add(shoppingCart);
                }
            }
        }
        if (shoppingCartToUpdate.Count > 0)
        {
            _shoppingCartRepository.UpdateRange(shoppingCartToUpdate);
            return true;
        }
        return false;
    }
}
