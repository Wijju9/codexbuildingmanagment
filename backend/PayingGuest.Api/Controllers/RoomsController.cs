using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayingGuest.Api.Contracts;
using PayingGuest.Api.Domain;
using PayingGuest.Api.Infrastructure.Persistence;

namespace PayingGuest.Api.Controllers;

[ApiController]
[Route("api/rooms")]
public sealed class RoomsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Room>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var rooms = await dbContext.Rooms
            .AsNoTracking()
            .OrderBy(x => x.RoomNumber)
            .ToListAsync(cancellationToken);

        return Ok(rooms);
    }

    [HttpPost]
    public async Task<ActionResult<Room>> CreateAsync([FromBody] CreateRoomRequest request, CancellationToken cancellationToken)
    {
        var propertyExists = await dbContext.Properties.AnyAsync(x => x.Id == request.PropertyId, cancellationToken);
        if (!propertyExists)
        {
            return BadRequest("Property does not exist.");
        }

        var room = new Room
        {
            PropertyId = request.PropertyId,
            RoomNumber = request.RoomNumber,
            MonthlyRentUsd = request.MonthlyRentUsd,
            IsAvailable = true
        };

        dbContext.Rooms.Add(room);
        await dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetAllAsync), new { id = room.Id }, room);
    }
}
