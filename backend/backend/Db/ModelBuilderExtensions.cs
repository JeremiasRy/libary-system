namespace Backend.Db;

using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

public static class ModelBuilderExtensions
{
    public static void AddUserConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<IdentityRole<int>>().ToTable("roles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("role_claims");
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins");
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_roles");
        
        modelBuilder.Entity<User>()
           .HasIndex(user => user.Firstname);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Lastname);

        modelBuilder.Entity<User>()
            .HasIndex(user => new { user.Firstname, user.Lastname })
            .IsUnique();

        modelBuilder.Entity<User>()
            .Navigation(user => user.Loans)
            .AutoInclude();
    }
    public static void AddTimestampConfig(this ModelBuilder modelBuilder)
    {
        foreach (var propertyName in modelBuilder.Model.GetEntityTypes().Select(s => s.Name))
        {
            modelBuilder.Entity(propertyName)
                .Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity(propertyName)
                .Property<DateTime>("UpdatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
    public static void AddBookConfig(this ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Book>()
            .Navigation(book => book.Publishers)
            .AutoInclude();
    }
    public static void AddLoanConfig(this ModelBuilder modelBuilder)
    {
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
    }
    public static void AddCategoryConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasIndex(category => category.Title)
            .IsUnique();
    }
    public static void AddPublisherConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>()
            .HasIndex(publisher => publisher.PublisherName)
            .IsUnique();
    }
    public static void AddAuthorConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasIndex(author => new { author.Firstname, author.Lastname })
            .IsUnique();

        modelBuilder.Entity<Author>()
            .HasIndex(author => author.Firstname);

        modelBuilder.Entity<Author>()
            .HasIndex(author => author.Lastname);
    }
    public static void AddCopyConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Copy>()
            .Navigation(copy => copy.Publisher)
            .AutoInclude();

        modelBuilder.Entity<Copy>()
            .Navigation(copy => copy.Book)
            .AutoInclude();
    }
}
