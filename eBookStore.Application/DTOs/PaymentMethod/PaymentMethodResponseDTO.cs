namespace eBookStore.Application.DTOs.PaymentMethod;

public record PaymentMethodResponseDTO(
    int Id,
    int UserId,
    string CardHolderName,
    string CardNumber,
    int ExpirationMonth,
    int ExpirationYear,
    bool IsDefault);
