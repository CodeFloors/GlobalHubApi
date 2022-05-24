namespace GlobalHub.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ApplicationController : ControllerBase
{
    private readonly GlobalHubContext _context;

    public ApplicationController(GlobalHubContext context)
    {
        _context = context;
    }

    // GET: api/GetAllApplications
    [HttpGet("GetAll[controller]s")]
    public async Task<ActionResult<IEnumerable<Applications>>> GetAll()
    {
        return await _context.Applications.ToListAsync();
    }

    // GET: api/GetApplicationById/5
    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<Applications>> GetById(int id)
    {
        var applications = await _context.Applications.FindAsync(id);

        if (applications == null) {
            return NotFound();
        }

        return Ok(applications);
    }

    // PUT: api/UpdateApplicationById/5    
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(int id, Applications applications)
    {
        if (id != applications.PkapplicationsCode) {
            return BadRequest();
        }

        _context.Entry(applications).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            if (!ApplicationsExists(id)) {
                return NotFound();
            }
            else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/AddApplication    
    [HttpPost("Add[controller]")]
    public async Task<ActionResult<Applications>> Add(Applications applications)
    {
        _context.Applications.Add(applications);
        await _context.SaveChangesAsync();

        return Ok(applications);
    }

    // DELETE: api/DeleteApplicationById/5
    [HttpDelete("Delete[controller]ById/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var applications = await _context.Applications.FindAsync(id);
        if (applications == null) {
            return NotFound();
        }

        _context.Applications.Remove(applications);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationsExists(int id)
    {
        return _context.Applications.Any(e => e.PkapplicationsCode == id);
    }
}
