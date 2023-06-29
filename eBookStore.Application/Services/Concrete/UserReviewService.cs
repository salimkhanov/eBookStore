using AutoMapper;
using eBookStore.Application.DTOs.ShoppingCart;
using eBookStore.Application.DTOs.UserReview;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Application.Services.Concrete;

public class UserReviewService:IUserReviewService
{
    private readonly IUserReviewRepository _userReviewRepository;
	private readonly UserManager<User> _userManager;
	private readonly IMapper _mapper;

	public UserReviewService(IUserReviewRepository userReviewRepository,
		UserManager<User> userManager,
		IMapper mapper)
	{
		_userReviewRepository = userReviewRepository;
		_userManager = userManager;
        _mapper = mapper;
    }

    public bool ActivateUserReview(int userReviewId)
    {
        var userReview = _userReviewRepository.GetById(userReviewId);
        if (userReview != null && userReview.EntityStatus != EntityStatus.Active)
        {
            _userReviewRepository.Activate(userReview);
            return true;
        }
        return false;
    }

    public async Task<bool> CreateUserReview(CreateUserReviewDTO createUserReviewDTO)
    {
        var userId = await _userManager.FindByIdAsync(createUserReviewDTO.UserId.ToString());
        if (userId != null)
        {
            var userReview = _mapper.Map<UserReview>(createUserReviewDTO);
            _userReviewRepository.Add(userReview);
            return true;
        }
        return false;
    }

    public bool CreateUserReviews(List<CreateUserReviewDTO> createUserReviewDTOs)
    {
        var userIds = createUserReviewDTOs.Select(dto => dto.UserId).ToList();
        var users = _userManager.Users.Where(user => userIds.Contains(user.Id)).ToList();

        var userReviewsToAdd = createUserReviewDTOs
            .Where(dto => users.Any(user => user.Id == dto.UserId))
            .Select(dto => _mapper.Map<UserReview>(dto))
            .ToList();

        if (userReviewsToAdd.Count > 0)
        {
            _userReviewRepository.AddRange(userReviewsToAdd);
            return true;
        }
        return false;
    }

    public bool DeactivateUserReview(int userReviewId)
    {
        var userReview = _userReviewRepository.GetById(userReviewId);
        if (userReview != null && userReview.EntityStatus != EntityStatus.Deactive)
        {
            _userReviewRepository.Deactivate(userReview);
            return true;
        }
        return false;
    }

    public bool DeleteUserReview(int userReviewId)
    {
        var userReview = _userReviewRepository.GetById(userReviewId);

        if (userReview != null)
        {
            _userReviewRepository.Remove(userReview);
            return true;
        }
        return false;
    }

    public bool DeleteUserReviews(List<int> userReviews)
    {
        var userReviewsToDelete = _userReviewRepository.GetAll()
            .Where(x => userReviews.Contains(x.Id)).ToList();

        if (userReviewsToDelete != null && userReviewsToDelete.Count > 0)
        {
            _userReviewRepository.RemoveRange(userReviewsToDelete);
            return true;
        }
        return false;
    }

    public GetUserReviewDTO GetUserReviewById(int userReviewId)
    {
        var userReview = _userReviewRepository.GetById(userReviewId);
        return _mapper.Map<GetUserReviewDTO>(userReview);
    }

    public List<GetUserReviewDTO> GetUserReviews()
    {
        var userReviews = _userReviewRepository.GetAll();
        return _mapper.Map<List<GetUserReviewDTO>>(userReviews);
    }

    public async Task<bool> UpdateUserReview(UpdateUserReviewDTO updateUserReviewDTO)
    {
        var userId = await _userManager.FindByIdAsync(updateUserReviewDTO.UserId.ToString());

        if (userId != null)
        {
            var userReview = _userReviewRepository.GetById(updateUserReviewDTO.Id);
            if (userReview != null && userReview.EntityStatus != EntityStatus.Deactive)
            {
                userReview.UserId = updateUserReviewDTO.UserId;
                userReview.OrderLineId = updateUserReviewDTO.OrderLineId;
                userReview.RatingValue = updateUserReviewDTO.RatingValue;
                userReview.Comment = updateUserReviewDTO.Comment;
                _userReviewRepository.Update(userReview);
                return true;
            }
            return false;
        }
        return false;
    }

    public async Task<bool> UpdateUserReviews(List<UpdateUserReviewDTO> updateUserReviewDTOs)
    {
        List<UserReview> userReviewToUpdate = new List<UserReview>();

        foreach (var userReviewDTO in updateUserReviewDTOs)
        {
            var userId = await _userManager.FindByIdAsync(userReviewDTO.UserId.ToString());
            if (userId != null)
            {
                var userReview = _userReviewRepository.GetById(userReviewDTO.Id);
                if (userReview != null)
                {
                    userReview.UserId = userReviewDTO.UserId;
                    userReview.OrderLineId = userReviewDTO.OrderLineId;
                    userReview.RatingValue = userReviewDTO.RatingValue;
                    userReview.Comment = userReviewDTO.Comment;
                    userReviewToUpdate.Add(userReview);
                }
            }
        }
        if (userReviewToUpdate.Count > 0)
        {
            _userReviewRepository.UpdateRange(userReviewToUpdate);
            return true;
        }
        return false;
    }
}
