namespace GlobalHub.Entities;
public partial class ApplicationsAccounts
{
    public ApplicationsAccounts()
    {
        ApplicationParameters = new HashSet<ApplicationParameters>();
    }
    [Key]
    public long PkAccountCode { get; set; }
    public string AccountName { get; set; }

    [ForeignKey("Users")]
    public long FkuserId { get; set; }
    public virtual Users Users { get; set; }


    [ForeignKey("Applications")]
    public int FkApplicationCode { get; set; }
    public virtual Applications Applications { get; set; }

    public bool Active { get; set; }
    public virtual ICollection<ApplicationParameters> ApplicationParameters { get; set; }

}
