using eBookStore.Application.DTOs.Publisher;

namespace eBookStore.Application.Services.Abstract;

public interface IPublisherService
{
    Task<List<PublisherDTO>> GetPublishersAsync();
    Task<PublisherDTO> GetPublisherByIdAsync(int id);
    Task<bool> CreatePublisherAsync(PublisherDTO publisherDTO);
    Task<bool> UpdatePublisherAsync(PublisherDTO publisherDTO); 
    Task<bool> DeletePublisherAsync(int id);     
    Task<bool> PublisherExistsAsync(string name);
}
