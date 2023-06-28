using AutoMapper;
using eBookStore.Application.DTOs.ShoppingCartItem;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class ShoppingCartItemService:IShoppingCartItemService
{
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IMapper _mapper;
    public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository,
        IShoppingCartRepository shoppingCartRepository,
        IMapper mapper)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
    }

    public bool ActivateShoppingCartItem(int shoppingCartItemId)
    {
        var shoppingCartItem = _shoppingCartItemRepository.GetById(shoppingCartItemId);
        if (shoppingCartItem != null && shoppingCartItem.EntityStatus != EntityStatus.Active)
        {
            _shoppingCartItemRepository.Activate(shoppingCartItem);
            return true;
        }
        return false;
    }

    public bool CreateShoppingCartItem(CreateShoppingCartItemDTO createShoppingCartItemDTO)
    {
        var ShoppingCartId = _shoppingCartRepository.GetById(createShoppingCartItemDTO.CartId);
        if (ShoppingCartId != null)
        {
            var ShoppingCartItem = _mapper.Map<ShoppingCartItem>(createShoppingCartItemDTO);
            _shoppingCartItemRepository.Add(ShoppingCartItem);
            return true;
        }
        return false;
    }

    public bool CreateShoppingCartItems(List<CreateShoppingCartItemDTO> createShoppingCartItemDTOs)
    {
        var shoppingCarts = _shoppingCartRepository.GetAll();
        var shoppingCartItemsToAdd = createShoppingCartItemDTOs
            .Where(dto => shoppingCarts.Any(shoppingCart => shoppingCart.Id == dto.CartId))
            .Select(dto => _mapper.Map<ShoppingCartItem>(dto))
            .ToList();

        if (shoppingCartItemsToAdd.Count > 0)
        {
            _shoppingCartItemRepository.AddRange(shoppingCartItemsToAdd);
            return true;
        }
        return false;
    }

    public bool DeactivateShoppingCartItem(int shoppingCartItemId)
    {
        var shoppingCartItem = _shoppingCartItemRepository.GetById(shoppingCartItemId);
        if (shoppingCartItem != null && shoppingCartItem.EntityStatus != EntityStatus.Deactive)
        {
            _shoppingCartItemRepository.Deactivate(shoppingCartItem);
            return true;
        }
        return false;
    }

    public bool DeleteShoppingCartItem(int shoppingCartItemId)
    {
        var shoppingCartItem = _shoppingCartItemRepository.GetById(shoppingCartItemId);

        if (shoppingCartItem != null)
        {
            _shoppingCartItemRepository.Remove(shoppingCartItem);
            return true;
        }
        return false;
    }

    public bool DeleteShoppingCartItems(List<int> shoppingCartItems)
    {
        var shoppingCartItemsToDelete = _shoppingCartItemRepository.GetAll()
            .Where(x => shoppingCartItems.Contains(x.Id)).ToList();

        if (shoppingCartItemsToDelete != null && shoppingCartItemsToDelete.Count > 0)
        {
            _shoppingCartItemRepository.RemoveRange(shoppingCartItemsToDelete);
            return true;
        }
        return false;
    }

    public GetShoppingCartItemDTO GetShoppingCartItemById(int shoppingCartItemId)
    {
        var shoppingCartItem = _shoppingCartItemRepository.GetById(shoppingCartItemId);
        return _mapper.Map<GetShoppingCartItemDTO>(shoppingCartItem);
    }

    public List<GetShoppingCartItemDTO> GetShoppingCartItems()
    {
        var shoppingCartItems = _shoppingCartItemRepository.GetAll();
        return _mapper.Map<List<GetShoppingCartItemDTO>>(shoppingCartItems);
    }

    public bool UpdateShoppingCartItem(UpdateShoppingCartItemDTO updateShoppingCartItemDTO)
    {
        var shoppingCartId = _shoppingCartRepository.GetById(updateShoppingCartItemDTO.CartId);

        if (shoppingCartId != null)
        {
            var shoppingCartItem = _shoppingCartItemRepository.GetById(updateShoppingCartItemDTO.Id);
            if (shoppingCartItem != null && shoppingCartItem.EntityStatus != EntityStatus.Deactive)
            {
                shoppingCartItem.CartId = updateShoppingCartItemDTO.CartId;
                shoppingCartItem.BookItemId = updateShoppingCartItemDTO.BookItemId;
                shoppingCartItem.Quantity = updateShoppingCartItemDTO.Quantity;
                _shoppingCartItemRepository.Update(shoppingCartItem);
                return true;
            }
            return false;
        }
        return false;
    }

    public bool UpdateShoppingCartItems(List<UpdateShoppingCartItemDTO> updateShoppingCartItemsDTOs)
    {
        List<ShoppingCartItem> shoppingCartItemsToUpdate = new List<ShoppingCartItem>();

        foreach (var shoppingCartItemDTO in updateShoppingCartItemsDTOs)
        {
            var shoppingCartId = _shoppingCartRepository.GetById(shoppingCartItemDTO.CartId);
            if (shoppingCartId != null)
            {
                var shoppingCartItem = _shoppingCartItemRepository.GetById(shoppingCartItemDTO.Id);
                if (shoppingCartItem != null)
                {
                    shoppingCartItem.CartId = shoppingCartItemDTO.CartId;
                    shoppingCartItem.BookItemId = shoppingCartItemDTO.BookItemId;
                    shoppingCartItem.Quantity = shoppingCartItemDTO.Quantity;
                    shoppingCartItemsToUpdate.Add(shoppingCartItem);
                }
            }
        }
        if (shoppingCartItemsToUpdate.Count > 0)
        {
            _shoppingCartItemRepository.UpdateRange(shoppingCartItemsToUpdate);
            return true;
        }
        return false;
    }
}
