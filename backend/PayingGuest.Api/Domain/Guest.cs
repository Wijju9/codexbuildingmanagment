namespace PayingGuest.Api.Domain;

public sealed class Guest : BaseEntity
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateOnly MoveInDate { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<GuestAssignment> Assignments { get; set; } = new List<GuestAssignment>();
}
