namespace PayingGuest.Api.Contracts;

public sealed record CreateRoomRequest(
    Guid PropertyId,
    string RoomNumber,
    decimal MonthlyRentUsd);
