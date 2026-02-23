using src.Models;

namespace src.Database;

using Microsoft.EntityFrameworkCore;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<Book> Book { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Loan> Loan { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1440;Database=librarium-real;User Id=sa;Password=SuperSecret7!;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<Loan>().ToTable("Loans");
        modelBuilder.Entity<Member>().ToTable("Members");

        modelBuilder.Entity<Loan>()
            .HasOne(m => m.Member)
            .WithMany(l => l.Loans)
            .HasForeignKey(m =>m.MemberId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Loan>()
            .HasOne(b => b.Book)
            .WithMany(l => l.Loans)
            .HasForeignKey(b => b.BookId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}