using AutoMapper;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(
        IAuthorRepository authorRepository,
        IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<bool> AuthorExistsAsync(string name)
    {
        var author = (await _authorRepository.FindAsync(a => a.Name.Trim().ToLower() == name.Trim().ToLower())).FirstOrDefault();
        if (author == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> CreateAuthorAsync(AuthorDTO authorDTO)
    {
        if(!await AuthorExistsAsync(authorDTO.Name))
        {
            var mapped = _mapper.Map<Author>(authorDTO);
            await _authorRepository.AddAsync(mapped);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author != null)
        {
            await _authorRepository.RemoveAsync(author);
            return true;
        }
        return false;
    }

    public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        return _mapper.Map<AuthorDTO>(author);
    }

    public async Task<List<AuthorDTO>> GetAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return _mapper.Map<List<AuthorDTO>>(authors);
    }

    public async Task<bool> UpdateAuthorAsync(AuthorDTO authorDTO)
    {
        var author = await _authorRepository.GetByIdAsync(authorDTO.Id);
        if (author != null)
        {
            _mapper.Map(authorDTO, author);
            await _authorRepository.UpdateAsync(author);
            return true;
        }
        return false;
    }
}
