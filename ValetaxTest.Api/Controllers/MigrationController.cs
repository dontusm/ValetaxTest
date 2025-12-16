using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValetaxTest.Infrastructure.Data;

namespace ValetaxTest.Api.Controllers;

[ApiController]
[Route("api/migrations")]
public class MigrationController : ControllerBase
{
    private readonly DataContext _dbContext;
    private readonly ILogger<MigrationController> _logger;

    public MigrationController(DataContext dbContext, ILogger<MigrationController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Applies database migrations.
    /// </summary>
    [HttpPost("apply")]
    public async Task<IActionResult> ApplyMigrations()
    {
        try
        {
            _logger.LogInformation("Starting database migrations...");
            await _dbContext.Database.MigrateAsync();
            _logger.LogInformation("Database migrations applied successfully.");
            return Ok("Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while applying database migrations.");
            return StatusCode(500, "Error occurred while applying database migrations.");
        }
    }
}
