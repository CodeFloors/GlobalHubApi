public partial class GlobalHubContext : DbContext
{
    public GlobalHubContext()
    {
    }

    public GlobalHubContext(DbContextOptions<GlobalHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applications> Applications { get; set; } = null!;
    public virtual DbSet<ApplicationParameters> ApplicationParameters { get; set; } = null!;
    public virtual DbSet<ApplicationParameterNames> ApplicationParameterNames { get; set; } = null!;
    public virtual DbSet<ApplicationsAccounts> ApplicationsAccounts { get; set; } = null!;
    public virtual DbSet<Users> Users { get; set; } = null!;
    public virtual DbSet<Counteries> Counteries { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
