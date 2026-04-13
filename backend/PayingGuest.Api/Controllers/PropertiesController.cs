using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayingGuest.Api.Contracts;
using PayingGuest.Api.Domain;
using PayingGuest.Api.Infrastructure.Persistence;

namespace PayingGuest.Api.Controllers;

[ApiController]
[Route("api/properties")]
public sealed class PropertiesController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Property>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var properties = await dbContext.Properties
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

        return Ok(properties);
    }

    [HttpPost]
    public async Task<ActionResult<Property>> CreateAsync([FromBody] CreatePropertyRequest request, CancellationToken cancellationToken)
    {
        var property = new Property
        {
            Name = request.Name,
            City = request.City,
            StateCode = request.StateCode,
            ZipCode = request.ZipCode
        };

        dbContext.Properties.Add(property);
        await dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetAllAsync), new { id = property.Id }, property);
    }
}
