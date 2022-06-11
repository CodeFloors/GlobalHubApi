namespace GlobalHub.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly GlobalHubContext _context;

    public UserController(GlobalHubContext context)
    {
        _context = context;
    }

    [HttpGet("GetAll[controller]s")]
    public async Task<ActionResult<IEnumerable<Users>>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    // GET: api/GetUserById/1

    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<Users>> GetById(long id)
    {
        var users = await _context.Users
       .Include(x => x.FKApplicationsAccountNavigation)
       .ThenInclude(y => y.ApplicationParameters)
       .FirstOrDefaultAsync(z => z.userid == id);

        if (users is null)
            return NotFound();

        return Ok(users);
    }

    // PUT: api/UpdateUserById/1
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, Users users)
    {
        if (id != users.userid)
            return BadRequest();

        _context.Entry(users).State = EntityState.Modified;

        try {
            _ = await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            if (!UserExists(id)) {
                return NotFound();
            }
            else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/AddUser
    [HttpPost("Add[controller]")]
    public async Task<ActionResult<Users>> Add(Users users)
    {
        _ = _context.Users.Add(users);
        _ = await _context.SaveChangesAsync();

        return Ok(users);
    }

    // DELETE: api/DeleteUserById/1
    [HttpDelete("Delete[controller]ById/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var users = await _context.Users.FindAsync(id);
        if (users is null)
            return NotFound();

        _ = _context.Users.Remove(users);
        _ = await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(long id)
    {
        return _context.Users.Any(e => e.userid == id);
    }
}
