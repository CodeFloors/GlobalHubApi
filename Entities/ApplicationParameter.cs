namespace GlobalHub.Entities;
public partial class ApplicationParameters
{
    public ApplicationParameters()
    {
        ApplicationParameterNamesList = new HashSet<ApplicationParameterNames>();
    }
    [Key] 
    public long PkapplicationParameterCode { get; set; }
    public string ParameterName { get; set; }
    public string ParameterValue { get; set; }

    [ForeignKey("ApplicationsAccounts")]
    public long FkAccountCode { get; set; }
    public virtual ApplicationsAccounts ApplicationsAccounts { get; set; }

    [NotMapped]
    public virtual ICollection<ApplicationParameterNames> ApplicationParameterNamesList { get; set; }

}
