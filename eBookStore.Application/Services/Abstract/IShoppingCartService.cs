using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.ShoppingCart;

namespace eBookStore.Application.Services.Abstract;

public interface IShoppingCartService
{
    List<GetShoppingCartDTO> GetShoppingCarts();
    GetShoppingCartDTO GetShoppingCartById(int shoppingCartId);
    Task<bool> CreateShoppingCart(CreateShoppingCartDTO createShoppingCartDTO);
    Task<bool> UpdateShoppingCart(UpdateShoppingCartDTO updateShoppingCartDTO);
    bool DeleteShoppingCart(int shoppingCartId);
    bool DeactivateShoppingCart(int shoppingCartId);
    bool ActivateShoppingCart(int shoppingCartId);
    bool CreateShoppingCarts(List<CreateShoppingCartDTO> createShoppingCartDTOs);
    bool DeleteShoppingCarts(List<int> shoppingCarts);
    Task<bool> UpdateShoppingCarts(List<UpdateShoppingCartDTO> updateShoppingCartDTOs);
}
