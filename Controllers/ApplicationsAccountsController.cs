namespace GlobalHub.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ApplicationAccountController : ControllerBase
{
    private readonly GlobalHubContext _context;

    public ApplicationAccountController(GlobalHubContext context)
    {
        _context = context;
    }

    // GET: api/GetApplicationAccounts
    [HttpGet("GetAll[controller]s")]
    public async Task<ActionResult<IEnumerable<ApplicationsAccounts>>> GetAll()
    {
        return await _context.ApplicationsAccounts.ToListAsync();
    }

    // GET: api/GetApplicationAccountById/1
    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<ApplicationsAccounts>> GetById(long id)
    {
        var exists = await _context.ApplicationsAccounts.FindAsync(id);

        if (exists is null) return NotFound();

        var results = from applicationAcocunt in _context.ApplicationsAccounts

                       join parameter in _context.ApplicationParameters
                       on applicationAcocunt.PkAccountCode equals parameter.FkAccountCode into firstJoinLeft
                       from fj in firstJoinLeft.DefaultIfEmpty()

                       join parameterName in _context.ApplicationParameterNames
                       on new { fj.PkapplicationParameterCode, fj.ParameterName } equals new { parameterName.PkapplicationParameterCode, parameterName.ParameterName } into secondJoinLeft
                       from sj in secondJoinLeft.DefaultIfEmpty()

                       select new ApplicationsAccounts {
                           AccountName = applicationAcocunt.AccountName,
                           Active = applicationAcocunt.Active,
                           ApplicationParameters = new List<ApplicationParameters> {
                               new ApplicationParameters() {
                                   ApplicationParameterNamesList=new List<ApplicationParameterNames>() {
                                       new ApplicationParameterNames() {
                                           Active=sj.Active,
                                           DataType=sj.DataType,
                                           DisplayName=sj.DisplayName,
                                           DisplaySequence=sj.DisplaySequence,
                                           FieldType=sj.DataType,
                                           FieldValues=sj.FieldValues,
                                           FkApplicationCode=sj.FkApplicationCode,
                                           HelpText=sj.HelpText,
                                           HelpUrl=sj.HelpUrl,
                                           IncludeInInventoryAPI=sj.IncludeInInvoiceAPI,
                                           IncludeInInvoiceAPI=sj.IncludeInInvoiceAPI,
                                           IncludeInLabelAPI=sj.IncludeInInvoiceAPI,
                                           IncludeInOrdersAPI=sj.IncludeInInvoiceAPI,
                                           PageTab=sj.PageTab,
                                           ParameterName=sj.ParameterName,
                                           IncludeInDispatchAPI=sj.IncludeInInvoiceAPI,
                                           PkapplicationParameterCode=sj.PkapplicationParameterCode,
                                       }
                                   },
                                   FkAccountCode=fj.FkAccountCode,
                                   ParameterName=fj.ParameterName,
                                   ParameterValue=fj.ParameterName,
                                   PkapplicationParameterCode=fj.PkapplicationParameterCode,
                               }
                           },
                           FkApplicationCode = applicationAcocunt.FkApplicationCode,
                           FkuserId = applicationAcocunt.FkuserId,
                           PkAccountCode = applicationAcocunt.PkAccountCode
                       };
        
        return Ok(results);
    }

    // PUT: api/UpdateApplicationAccountById/1
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, ApplicationsAccounts applicationsAccounts)
    {
        if (id != applicationsAccounts.PkAccountCode) {
            return BadRequest();
        }

        _context.Entry(applicationsAccounts).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            if (!ApplicationsAccountsExists(id)) {
                return NotFound();
            }
            else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/AddApplicationAccount
    [HttpPost("Add[controller]")]
    public async Task<ActionResult<ApplicationsAccounts>> Add(ApplicationsAccounts applicationsAccounts)
    {
        _context.ApplicationsAccounts.Add(applicationsAccounts);
        await _context.SaveChangesAsync();

        return Ok(applicationsAccounts);
    }

    // DELETE: api/DeleteApplicationAccountById/1
    [HttpDelete("Delete[controller]ById/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var applicationsAccounts = await _context.ApplicationsAccounts.FindAsync(id);
        if (applicationsAccounts == null) {
            return NotFound();
        }

        _context.ApplicationsAccounts.Remove(applicationsAccounts);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationsAccountsExists(long id)
    {
        return _context.ApplicationsAccounts.Any(e => e.PkAccountCode == id);
    }
}
