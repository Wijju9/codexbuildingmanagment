namespace PayingGuest.Api.Contracts;

public sealed record CreatePropertyRequest(
    string Name,
    string City,
    string StateCode,
    string ZipCode);
