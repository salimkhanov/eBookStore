using AutoMapper;
using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Publisher;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public PublisherService(
        IPublisherRepository publisherRepository,
        IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }
    public async Task<bool> CreatePublisherAsync(PublisherDTO publisherDTO)
    {
        if (!await PublisherExistsAsync(publisherDTO.Name))
        {
            var mapped = _mapper.Map<Publisher>(publisherDTO);
            await _publisherRepository.AddAsync(mapped);
            return true;
        }
        return false;
    }

    public async Task<bool> DeletePublisherAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher != null)
        {
            await _publisherRepository.RemoveAsync(publisher);
            return true;
        }
        return false;
    }

    public async Task<PublisherDTO> GetPublisherByIdAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        return _mapper.Map<PublisherDTO>(publisher);
    }

    public async Task<List<PublisherDTO>> GetPublishersAsync()
    {
        var publishers = await _publisherRepository.GetAllAsync();
        return _mapper.Map<List<PublisherDTO>>(publishers);
    }

    public async Task<bool> PublisherExistsAsync(string name)
    {
        var publisher = (await _publisherRepository.FindAsync(a => a.Name.Trim().ToLower() == name.Trim().ToLower())).FirstOrDefault();
        if (publisher == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> UpdatePublisherAsync(PublisherDTO publisherDTO)
    {
        var publisher = await _publisherRepository.GetByIdAsync(publisherDTO.Id);
        if (publisher != null)
        {
            _mapper.Map(publisherDTO, publisher);
            await _publisherRepository.UpdateAsync(publisher);
            return true;
        }
        return false;
    }
}
