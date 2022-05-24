namespace GlobalHub.Entities;
public partial class Applications
{
    public Applications()
    {
        ApplicationsAccounts = new HashSet<ApplicationsAccounts>();
        ApplicationParameterNames = new HashSet<ApplicationParameterNames>();
    }

    [Key]
    public int PkapplicationsCode { get; set; }
    public virtual ICollection<ApplicationsAccounts> ApplicationsAccounts { get; set; }
    public virtual ICollection<ApplicationParameterNames> ApplicationParameterNames { get; set; }


    public string ApplicationName { get; set; }
    public string Imageurl { get; set; }
    public bool Active { get; set; }
    public bool AllowsDownloads { get; set; }
    public bool AllowsInventoryUpdates { get; set; }
    public bool AllowsLabelGeneration { get; set; }
    public bool AllowsInvoicing { get; set; }
    public decimal PricePerMonth { get; set; }
    public string ApplicationType { get; set; }

}
