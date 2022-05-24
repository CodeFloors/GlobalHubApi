namespace GlobalHub.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ApplicationParameterController : ControllerBase
{
    private readonly GlobalHubContext _context;

    public ApplicationParameterController(GlobalHubContext context)
    {
        _context = context;
    }

    // GET: api/ApplicationParameters
    [HttpGet("GetAll[controller]s")]
    public async Task<ActionResult<IEnumerable<ApplicationParameters>>> GetAll()
    {
        return await _context.ApplicationParameters.ToListAsync();
    }

    // GET: api/GetApplicationParameterById/1
    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<ApplicationParameters>> GetById(long id)
    {
        var applicationParameters = await _context.ApplicationParameters.FindAsync(id);

        if (applicationParameters == null) {
            return NotFound();
        }

        return Ok(applicationParameters);
    }

    // PUT: api/UpdateApplicationParameterById/1    
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, ApplicationParameters applicationParameters)
    {
        if (id != applicationParameters.PkapplicationParameterCode) {
            return BadRequest();
        }

        _context.Entry(applicationParameters).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            if (!ApplicationParametersExists(id)) {
                return NotFound();
            }
            else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/AddApplicationParameter    
    [HttpPost("Add[controller]")]
    public async Task<ActionResult<ApplicationParameters>> Add(ApplicationParameters applicationParameters)
    {
        _context.ApplicationParameters.Add(applicationParameters);
        await _context.SaveChangesAsync();

        return Ok(applicationParameters);
    }

    // DELETE: api/DeleteApplicationParameterById/1
    [HttpDelete("Delete[controller]ById/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var applicationParameters = await _context.ApplicationParameters.FindAsync(id);
        if (applicationParameters == null) {
            return NotFound();
        }

        _context.ApplicationParameters.Remove(applicationParameters);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationParametersExists(long id)
    {
        return _context.ApplicationParameters.Any(e => e.PkapplicationParameterCode == id);
    }
}
