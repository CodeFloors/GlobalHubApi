namespace GlobalHub.Entities;
public partial class ApplicationParameterNames
{
    [Key]
    public long PkapplicationParameterCode { get; set; }
    public string ParameterName { get; set; }

    [ForeignKey("Applications")]
    public int FkApplicationCode { get; set; }
    public virtual Applications Applications { get; set; }


    public int PageTab { get; set; }
    public string DisplayName { get; set; }
    public string DataType { get; set; }
    public string FieldType { get; set; }
    public string FieldValues { get; set; }
    public int DisplaySequence { get; set; }
    public bool Active { get; set; }

    public   bool IncludeInOrdersAPI {get;set;}
    public   bool IncludeInDispatchAPI {get;set;}
    public   bool IncludeInLabelAPI {get;set;}
    public   bool IncludeInInvoiceAPI {get;set;}
    public   bool IncludeInInventoryAPI {get;set;}
    public   string HelpText {get;set;}
    public string HelpUrl { get; set; }

}
