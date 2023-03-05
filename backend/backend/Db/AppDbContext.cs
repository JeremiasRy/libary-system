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
        
        foreach (var propertyName in modelBuilder.Model.GetEntityTypes().Select(s => s.Name))
        {
            modelBuilder.Entity(propertyName)
                .Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity(propertyName)
                .Property<DateTime>("UpdatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
        
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

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.User)
            .WithMany(user => user.Loans)
            .OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey(loan => loan.UserId);

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.Copy)
            .WithMany(copy => copy.Loans)
            .OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey(loan => loan.CopyId);

        modelBuilder.Entity<Loan>()
            .Navigation(loan => loan.Copy)
            .AutoInclude();

        modelBuilder.Entity<Loan>()
            .Navigation(loan => loan.User)
            .AutoInclude();

        modelBuilder.Entity<Book>()
            .HasIndex(book => book.Title)
            .IsUnique();

        modelBuilder.Entity<Book>()
            .Navigation(book => book.Categories)
            .AutoInclude();

        modelBuilder.Entity<Book>()
            .Navigation(book => book.Authors)
            .AutoInclude();

        modelBuilder.Entity<Book>()
            .Navigation(book => book.Copies)
            .AutoInclude();

        modelBuilder.Entity<CartItem>()
            .HasKey(cartItem => new { cartItem.CopyId, cartItem.UserId });

        modelBuilder.Entity<CartItem>()
            .Navigation(cartItem => cartItem.User)
            .AutoInclude();

        modelBuilder.Entity<CartItem>()
            .Navigation(cartItem => cartItem.Copy)
            .AutoInclude();

        modelBuilder.Entity<Copy>()
            .Navigation(copy => copy.Publisher)
            .AutoInclude();

        modelBuilder.Entity<Copy>()
            .Navigation(copy => copy.Book)
            .AutoInclude();

        modelBuilder.Entity<Author>()
            .HasIndex(author => new { author.Firstname, author.Lastname })
            .IsUnique();

        modelBuilder.Entity<Author>()
            .HasIndex(author => author.Firstname);

        modelBuilder.Entity<Author>()
            .HasIndex(author => author.Lastname);

        modelBuilder.Entity<Category>()
            .HasIndex(category => category.Title)
            .IsUnique();

        modelBuilder.Entity<Publisher>()
            .HasIndex(publisher => publisher.PublisherName)
            .IsUnique();
    }
}
