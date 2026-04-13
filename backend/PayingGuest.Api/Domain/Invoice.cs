namespace PayingGuest.Api.Domain;

public sealed class Invoice : BaseEntity
{
    public Guid GuestId { get; set; }
    public Guest? Guest { get; set; }

    public decimal AmountUsd { get; set; }
    public DateOnly BillingMonth { get; set; }
    public DateOnly DueDate { get; set; }
    public bool IsPaid { get; set; }
}
