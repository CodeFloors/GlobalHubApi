namespace GlobalHub.Entities;
public partial class Users
{
    public Users()
    {
        ApplicationsAccounts = new HashSet<ApplicationsAccounts>();
    }
    [Key]
    public long Userid { get; set; }
    public virtual ICollection<ApplicationsAccounts> ApplicationsAccounts { get; set; }

    public string Userfirstname { get; set; }
    public string Userlastname { get; set; }
    public string Usercompanyname { get; set; }
    public string Useraddress1 { get; set; }
    public string Useraddress2 { get; set; }
    public string Useraddress3 { get; set; }
    public string Usercity { get; set; }
    public string Usercounty { get; set; }
    public string Userstate { get; set; }
    public string Usercountrycode { get; set; }
    public string Userpostcode { get; set; }
    public string Usertelephone { get; set; }
    public string Useremail { get; set; }
    public string Password { get; set; }

}
