using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayingGuest.Api.Contracts;
using PayingGuest.Api.Domain;
using PayingGuest.Api.Infrastructure.Persistence;

namespace PayingGuest.Api.Controllers;

[ApiController]
[Route("api/guests")]
public sealed class GuestsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Guest>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var guests = await dbContext.Guests
            .AsNoTracking()
            .OrderBy(x => x.FullName)
            .ToListAsync(cancellationToken);

        return Ok(guests);
    }

    [HttpPost]
    public async Task<ActionResult<Guest>> CreateAsync([FromBody] CreateGuestRequest request, CancellationToken cancellationToken)
    {
        var guest = new Guest
        {
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            MoveInDate = request.MoveInDate
        };

        dbContext.Guests.Add(guest);
        await dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetAllAsync), new { id = guest.Id }, guest);
    }
}
