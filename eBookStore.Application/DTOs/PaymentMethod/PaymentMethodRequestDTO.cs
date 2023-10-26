namespace eBookStore.Application.DTOs.PaymentMethod;

public record PaymentMethodRequestDTO(
    int Id,
    string CardHolderName,
    string CardNumber,
    int ExpirationMonth,
    int ExpirationYear,
    bool IsDefault);
