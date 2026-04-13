namespace PayingGuest.Api.Domain;

public sealed class Property : BaseEntity
{
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string StateCode { get; set; }
    public required string ZipCode { get; set; }
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
