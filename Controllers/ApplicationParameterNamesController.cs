namespace GlobalHub.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ApplicationParameterNameController : ControllerBase
{
    private readonly GlobalHubContext _context;

    public ApplicationParameterNameController(GlobalHubContext context)
    {
        _context = context;
    }

    // GET: api/ApplicationParameterNames
    [HttpGet("GetAll[controller]s")]
    public async Task<ActionResult<IEnumerable<ApplicationParameterName>>> GetAll()
    {
        return await _context.ApplicationParameterNames.ToListAsync();
    }

    // GET: api/GetApplicationParameterNameById/1
    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<ApplicationParameterName>> GetById(long id)
    {
        var applicationParameterNames = await _context.ApplicationParameterNames.FindAsync(id);

        if (applicationParameterNames == null) {
            return NotFound();
        }

        return Ok(applicationParameterNames);
    }

    // PUT: api/UpdateApplicationParameterNameById/1    
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, ApplicationParameterName applicationParameterNames)
    {
        if (id != applicationParameterNames.PKApplicationParameterCode) {
            return BadRequest();
        }

        _context.Entry(applicationParameterNames).State = EntityState.Modified;

        try {
            _ = await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            if (!ApplicationParameterNamesExists(id)) {
                return NotFound();
            }
            else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/AddApplicationParameterName   
    [HttpPost("Add[controller]")]
    public async Task<ActionResult<ApplicationParameterName>> Add(ApplicationParameterName applicationParameterNames)
    {
        _ = _context.ApplicationParameterNames.Add(applicationParameterNames);
        _ = await _context.SaveChangesAsync();

        return Ok(applicationParameterNames);
    }

    // DELETE: api/DeleteApplicationParameterNameById/1
    [HttpDelete("Delete[controller]ById/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var applicationParameterNames = await _context.ApplicationParameterNames.FindAsync(id);
        if (applicationParameterNames == null) {
            return NotFound();
        }

        _ = _context.ApplicationParameterNames.Remove(applicationParameterNames);
        _ = await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationParameterNamesExists(long id)
    {
        return _context.ApplicationParameterNames.Any(e => e.PKApplicationParameterCode == id);
    }
}
