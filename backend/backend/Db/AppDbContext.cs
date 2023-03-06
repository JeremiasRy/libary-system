namespace Backend.Db;

using Microsoft.EntityFrameworkCore;
using Npgsql;
using Backend.Models;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext(IConfiguration configuration) => _configuration = configuration;
    static AppDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<User.UserRole>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionSting = _configuration.GetConnectionString("Default");
        
        options
            .UseNpgsql(connectionSting)
            .AddInterceptors(new AppDbContextSaveChangesInterceptors())
            .UseSnakeCaseNamingConvention();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<User.UserRole>();
        
        modelBuilder.AddTimestampConfig();
        modelBuilder.AddBookConfig();
        modelBuilder.AddLoanConfig();
        modelBuilder.AddPublisherConfig();
        modelBuilder.AddAuthorConfig();
        modelBuilder.AddCopyConfig();
        
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Firstname);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Lastname);

        modelBuilder.Entity<User>()
            .HasIndex(user => new { user.Firstname, user.Lastname })
            .IsUnique();

        modelBuilder.Entity<User>()
            .Navigation(user => user.CartItems)
            .AutoInclude();

        modelBuilder.Entity<User>()
            .Navigation(user => user.Loans)
            .AutoInclude();
    }
}
