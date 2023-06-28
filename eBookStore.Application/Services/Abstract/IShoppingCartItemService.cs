using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.ShoppingCartItem;

namespace eBookStore.Application.Services.Abstract;

public interface IShoppingCartItemService
{
    List<GetShoppingCartItemDTO> GetShoppingCartItems();
    GetShoppingCartItemDTO GetShoppingCartItemById(int shoppingCartItemId);
    bool CreateShoppingCartItem(CreateShoppingCartItemDTO createShoppingCartItemDTO);
    bool UpdateShoppingCartItem(UpdateShoppingCartItemDTO updateShoppingCartItemDTO);
    bool DeleteShoppingCartItem(int shoppingCartItemId);
    bool DeactivateShoppingCartItem(int shoppingCartItemId);
    bool ActivateShoppingCartItem(int shoppingCartItemId);
    bool CreateShoppingCartItems(List<CreateShoppingCartItemDTO> createShoppingCartItemDTOs);
    bool DeleteShoppingCartItems(List<int> shoppingCartItems);
    bool UpdateShoppingCartItems(List<UpdateShoppingCartItemDTO> updateShoppingCartItemsDTOs);
}
