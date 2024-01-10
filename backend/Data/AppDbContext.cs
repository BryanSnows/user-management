using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class AppDbContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public AppDbContext(DbContextOptions<AppDbContext> options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ProfileTransaction> ProfileTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory)
                      .EnableSensitiveDataLogging()
                      .UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=3663"); 
    }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("user")
        .HasKey(u => u.user_id); 
        modelBuilder.Entity<Profile>().ToTable("profile")
        .HasKey(u => u.profile_id); 
        modelBuilder.Entity<Transaction>().ToTable("transaction")
         .HasKey(u => u.transaction_id); 
        modelBuilder.Entity<ProfileTransaction>().ToTable("profile_transaction")
         .HasKey(u => u.profile_transaction_id); 

        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.profile_id);

        modelBuilder.Entity<ProfileTransaction>()
            .HasOne(pt => pt.Profile)
            .WithMany(p => p.ProfileTransactions)
            .HasForeignKey(pt => pt.profile_id);

        modelBuilder.Entity<ProfileTransaction>()
            .HasOne(pt => pt.Transaction)
            .WithMany(t => t.ProfileTransactions)
            .HasForeignKey(pt => pt.transaction_id);
    }
}