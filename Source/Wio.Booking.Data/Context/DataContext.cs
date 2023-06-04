using Microsoft.EntityFrameworkCore;
using Wio.Booking.Business.Models;

namespace Wio.Booking.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<CarRental> CarRentals { get; set; } = null!;
    public DbSet<Address> Address { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        foreach (var relationship in modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
        {
            //Crie uma dataAtual
            if (entry.State == EntityState.Added)
                entry.Property("RegistrationDate").CurrentValue = DateTime.Now;

            //Não salvar, não é modificado caso não tenha registro 
            if (entry.State == EntityState.Modified)
                entry.Property("RegistrationDate").IsModified = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}