namespace eBookStore.Application.DTOs.Authentication;

public record LoginDto(
    string Email,
    string Password);
