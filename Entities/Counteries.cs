#nullable disable
namespace GlobalHub.Entities;
public partial class Counteries
{
    [Key]
    public int Id { get; set; }
    public string PKCountryCode { get; set; }

    public string CountryName { get; set; }
}