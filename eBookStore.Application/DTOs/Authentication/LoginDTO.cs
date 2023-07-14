namespace eBookStore.Application.DTOs.Authentication;

public record LoginDTO(
    string Email,
    string Password);
