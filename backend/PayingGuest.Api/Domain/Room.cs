namespace PayingGuest.Api.Domain;

public sealed class Room : BaseEntity
{
    public required string RoomNumber { get; set; }
    public decimal MonthlyRentUsd { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Guid PropertyId { get; set; }
    public Property? Property { get; set; }

    public ICollection<GuestAssignment> Assignments { get; set; } = new List<GuestAssignment>();
}
