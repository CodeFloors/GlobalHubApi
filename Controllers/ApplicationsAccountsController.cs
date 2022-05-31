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
    public async Task<ActionResult<IEnumerable<ApplicationsAccount>>> GetAll()
    {
        return await _context.ApplicationsAccounts.ToListAsync();
    }

    // GET: api/GetApplicationAccountById/1
    [HttpGet("Get[controller]ById/{id}")]
    public async Task<ActionResult<ApplicationsAccount>> GetById(long id)
    {
        var exists = await _context.ApplicationsAccounts.FindAsync(id);

        if (exists is null) return NotFound();

        var results = from applicationAcocunt in _context.ApplicationsAccounts

                      join parameter in _context.ApplicationParameters
                      on applicationAcocunt.PKAccountCode equals parameter.FKApplicationCode into firstJoinLeft
                      from fj in firstJoinLeft.DefaultIfEmpty()

                      join parameterName in _context.ApplicationParameterNames
                      on new { fj.PKApplicationParameterCode, fj.ParameterName } equals new { parameterName.PKApplicationParameterCode, parameterName.ParameterName } into secondJoinLeft
                      from sj in secondJoinLeft.DefaultIfEmpty()

                      select new ApplicationsAccount {
                          AccountName = applicationAcocunt.AccountName,
                          Active = applicationAcocunt.Active,
                          ApplicationParameters = new List<ApplicationParameter> {
                               new ApplicationParameter() {
                                   ApplicationParameterNamesList=new List<ApplicationParameterName>() {
                                       new ApplicationParameterName() {
                                           Active=sj.Active,
                                           DataType=sj.DataType,
                                           DisplayName=sj.DisplayName,
                                           DisplaySequence=sj.DisplaySequence,
                                           FieldType=sj.DataType,
                                           FieldValues=sj.FieldValues,
                                           FKApplicationCode=sj.FKApplicationCode,
                                           HelpText=sj.HelpText,
                                           HelpUrl=sj.HelpUrl,
                                           IncludeInInventoryAPI=sj.IncludeInInvoiceAPI,
                                           IncludeInInvoiceAPI=sj.IncludeInInvoiceAPI,
                                           IncludeInLabelAPI=sj.IncludeInInvoiceAPI,
                                           IncludeInOrdersAPI=sj.IncludeInInvoiceAPI,
                                           PageTab=sj.PageTab,
                                           ParameterName=sj.ParameterName,
                                           IncludeInDispatchAPI=sj.IncludeInInvoiceAPI,
                                           PKApplicationParameterCode=sj.PKApplicationParameterCode,
                                       }
                                   },
                                   FKApplicationCode=fj.FKApplicationCode,
                                   ParameterName=fj.ParameterName,
                                   ParameterValue=fj.ParameterName,
                                   PKApplicationParameterCode=fj.PKApplicationParameterCode,
                               }
                           },
                          FKApplicationsCode = applicationAcocunt.FKApplicationsCode,
                          FKUserId = applicationAcocunt.FKUserId,
                          PKAccountCode = applicationAcocunt.PKAccountCode
                      };

        return Ok(results);
    }

    // PUT: api/UpdateApplicationAccountById/1
    [HttpPut("Update[controller]ById/{id}")]
    public async Task<IActionResult> Update(long id, ApplicationsAccount applicationsAccounts)
    {
        if (id != applicationsAccounts.PKAccountCode) {
            return BadRequest();
        }

        _context.Entry(applicationsAccounts).State = EntityState.Modified;

        try {
            _ = await _context.SaveChangesAsync();
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
    public async Task<ActionResult<ApplicationsAccount>> Add(ApplicationsAccount applicationsAccounts)
    {
        _ = _context.ApplicationsAccounts.Add(applicationsAccounts);
        _ = await _context.SaveChangesAsync();

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

        _ = _context.ApplicationsAccounts.Remove(applicationsAccounts);
        _ = await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationsAccountsExists(long id)
    {
        return _context.ApplicationsAccounts.Any(e => e.PKAccountCode == id);
    }
}
