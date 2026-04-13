namespace PayingGuest.Api.Contracts;

public sealed record CreateGuestRequest(
    string FullName,
    string Email,
    string PhoneNumber,
    DateOnly MoveInDate);
