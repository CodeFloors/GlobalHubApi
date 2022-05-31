namespace GlobalHub.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly GlobalHubContext _context;

    public AuthController(IConfiguration configuration, GlobalHubContext dbContext)
    {
        this._configuration = configuration;
        this._context = dbContext;
    }

    [HttpPost("GetToken")]
    public IActionResult GetToken(Users users)
    {
        try {
            var user = _context.Users.FirstAsync(x => x.useremail == users.useremail && x.password == users.password);

            if (user is null)
                return NotFound("User not found.");

            string token = new JwtSecurityTokenHandler().WriteToken(GetTokenConfiguration());
            return Ok(new { token = token, expire = DateTime.UtcNow.AddHours(3) });
        }
        catch (Exception) {

            throw;
        }
    }

    [Authorize]
    [HttpGet("RefreshToken")]
    public IActionResult RefreshToken()
    {
        try {
            string token = new JwtSecurityTokenHandler().WriteToken(GetTokenConfiguration());
            return Ok(new { token = token, expire = DateTime.UtcNow.AddHours(3) });
        }
        catch (Exception) {

            throw;
        }
    }

    private JwtSecurityToken GetTokenConfiguration()
    {
        Claim[] claims = new Claim[] {
        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iss,_configuration["jwt:Issuer"]),
        new Claim(JwtRegisteredClaimNames.Aud,_configuration["jwt:Audience"]),
        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
        new Claim(JwtRegisteredClaimNames.Exp,DateTime.UtcNow.AddHours(3).ToString())
        };
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["jwt:Key"]));
        SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _configuration["jwt:Issuer"],
            audience: _configuration["jwt:Audience"],
            expires: DateTime.UtcNow.AddHours(3),
            claims: claims,
            signingCredentials: signingCredentials
            );
    }
}