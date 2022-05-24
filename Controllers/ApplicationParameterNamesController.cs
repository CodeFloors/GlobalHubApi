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
    public async Task<ActionResult<IEnumerable<ApplicationParameterNames>>> GetAll()
    {
        return await _context.ApplicationParameterNames.ToListAsync();
    }

    // GET: api/GetApplicationParameterNameById/1
    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<ApplicationParameterNames>> GetById(long id)
    {
        var applicationParameterNames = await _context.ApplicationParameterNames.FindAsync(id);

        if (applicationParameterNames == null) {
            return NotFound();
        }

        return Ok(applicationParameterNames);
    }

    // PUT: api/UpdateApplicationParameterNameById/1    
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, ApplicationParameterNames applicationParameterNames)
    {
        if (id != applicationParameterNames.PkapplicationParameterCode) {
            return BadRequest();
        }

        _context.Entry(applicationParameterNames).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
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
    public async Task<ActionResult<ApplicationParameterNames>> Add(ApplicationParameterNames applicationParameterNames)
    {
        _context.ApplicationParameterNames.Add(applicationParameterNames);
        await _context.SaveChangesAsync();

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

        _context.ApplicationParameterNames.Remove(applicationParameterNames);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationParameterNamesExists(long id)
    {
        return _context.ApplicationParameterNames.Any(e => e.PkapplicationParameterCode == id);
    }
}
