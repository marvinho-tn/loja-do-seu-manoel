using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Infra.Configuration.Database;

/// <summary>
/// Classe de configuração do contexto de banco de dados.
/// </summary>
public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Order>()
            .HasKey(entity => entity.Id);
        
        modelBuilder
            .Entity<Product>()
            .HasKey(entity => entity.Id);
        
        modelBuilder
            .Entity<Box>()
            .HasKey(entity => entity.Id);
        
        modelBuilder
            .Entity<Dimensions>()
            .HasKey(entity => entity.Id);
        
        modelBuilder
            .Entity<BoxMold>()
            .HasKey(entity => new { entity.Height, entity.Length, entity.Width });

        modelBuilder
            .Entity<Order>()
            .HasMany(entity => entity.Products);
        
        modelBuilder
            .Entity<Order>()
            .HasMany(entity => entity.Boxes);
        
        modelBuilder
            .Entity<Box>()
            .HasMany(entity => entity.Products);
        
        modelBuilder
            .Entity<Product>()
            .HasOne(entity => entity.Dimensions);
        
        modelBuilder
            .Entity<BoxMold>()
            .HasData
            (
                new BoxMold
                {
                    Height = 30,
                    Width = 40,
                    Length = 80,
                },
                new BoxMold
                {
                    Height = 80,
                    Width = 50,
                    Length = 40,
                },
                new BoxMold
                {
                    Height = 50,
                    Width = 80,
                    Length = 60,
                }
            );
    }
}