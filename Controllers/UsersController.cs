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
    /// <summary>
    /// Hello
    /// </summary>
    /// <returns></returns>
    // GET: api/GetAllUsers
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
       .Include(x => x.ApplicationsAccounts)
       .ThenInclude(y => y.ApplicationParameters)
       .FirstOrDefaultAsync(z => z.Userid == id);

        if (users is null)
            return NotFound();

        return Ok(users);
    }

    // PUT: api/UpdateUserById/1
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, Users users)
    {
        if (id != users.Userid)
            return BadRequest();

        _context.Entry(users).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
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
        _context.Users.Add(users);
        await _context.SaveChangesAsync();

        return Ok(users);
    }

    // DELETE: api/DeleteUserById/1
    [HttpDelete("Delete[controller]ById/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var users = await _context.Users.FindAsync(id);
        if (users is null)
            return NotFound();

        _context.Users.Remove(users);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(long id)
    {
        return _context.Users.Any(e => e.Userid == id);
    }
}
