using DSW_3P_PR02.Models;
using Microsoft.EntityFrameworkCore;

namespace DSW_3P_PR02.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }
    public DbSet<Evento> Eventos => Set<Evento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.ToTable("Eventos", table =>
            {
                table.HasCheckConstraint(
                    "CK_Eventos_Nombre_NotBlank",
                    "LEN(LTRIM(RTRIM([Nombre]))) > 0");
                table.HasCheckConstraint(
                    "CK_Eventos_CupoMaximo_Positive",
                    "[CupoMaximo] > 0");
                table.HasCheckConstraint(
                    "CK_Eventos_Fecha_Valid",
                    "[Fecha] > '0001-01-01T00:00:00'");
            });

            entity.Property(evento => evento.Nombre).IsRequired();
        });
    }
}