using AutoMapper;
using eBookStore.Application.DTOs.Discount;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public DiscountService(
        IDiscountRepository discountRepository,
        IBookRepository bookRepository,
        IMapper mapper)
    {
        _discountRepository = discountRepository;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task CreateDiscountAsync(DiscountDTO discountDTO)
    {
        var mapped = _mapper.Map<Discount>(discountDTO);
        await _discountRepository.AddAsync(mapped);
    }

    public async Task<bool> DeleteDiscountAsync(int id)
    {
        var discount = await _discountRepository.GetByIdAsync(id);
        if (discount != null)
        {
            await _discountRepository.RemoveAsync(discount);
            return true;
        }
        return false;
    }

    public async Task<DiscountDTO> GetDiscountByIdAsync(int id)
    {
        var discount = await _discountRepository.GetByIdAsync(id);
        return _mapper.Map<DiscountDTO>(discount);
    }

    public async Task<List<DiscountDTO>> GetDiscountsAsync()
    {
        var discounts = await _discountRepository.GetAllAsync();
        return _mapper.Map<List<DiscountDTO>>(discounts);   
    }

    public async Task<bool> UpdateDiscountAsync(DiscountDTO discountDTO)
    {
        var discount = await _discountRepository.GetByIdAsync(discountDTO.Id);
        if (discount != null)
        {
            _mapper.Map(discountDTO, discount);
            await _discountRepository.UpdateAsync(discount);
            return true;
        }

        return false;
    }

    public async Task<bool> AddDiscountToBooksAsync(DiscountBookDTO discountBookDTO)
    {
        var discount = await _discountRepository.GetByIdAsync(discountBookDTO.DiscountId);
        if (discount == null)
        {
            return false;
        }

        var books = await _bookRepository.FindAsync(b => discountBookDTO.BookIds.Contains(b.Id));

        foreach (var book in books)
        {
            discount.Books.Add(book);
        }

        await _discountRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveDiscountFromAllBooksAsync(int discountId)
    {
        var discount = await _discountRepository.GetByIdAsync(discountId);
        if (discount == null)
        {
            return false;
        }

        var books = await _bookRepository.FindAsync(b => b.DiscountId == discountId);

        foreach (var book in books)
        {
            discount.Books.Remove(book);
            book.Discount = null;
            book.DiscountId = null;
        }

        await _bookRepository.SaveChangesAsync();
        return true;
    }
}
