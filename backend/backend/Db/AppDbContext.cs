﻿namespace backend.Db;

using Microsoft.EntityFrameworkCore;
using Npgsql;
using backend.Models;

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
            .HasIndex(user => user.Username);

        modelBuilder.Entity<User>()
            .HasIndex(user => new { user.Firstname, user.Lastname })
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(user => user.Loans);

        modelBuilder.Entity<Book>()
            .HasIndex(book => book.Title)
            .IsUnique();

        modelBuilder.Entity<Category>()
            .HasIndex(category => category.Title)
            .IsUnique();

        modelBuilder.Entity<Author>()
            .HasIndex(author => new { author.Firstname, author.Lastname })
            .IsUnique();

        modelBuilder.Entity<Loan>()
            .HasKey(loan => new { loan.CopyId, loan.UserId });

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.Copy)
            .WithMany();

        modelBuilder.Entity<CartItem>()
            .HasKey(cartItem => new { cartItem.CopyId, cartItem.UserId });
    }
}