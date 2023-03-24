using System;
using System.Collections.Generic;
using DesmodusTemplate.Entities.Artec;
using Microsoft.EntityFrameworkCore;

namespace DesmodusTemplate.Data;

public partial class ArtecContext : DbContext
{
    public ArtecContext()
    {
    }

    public ArtecContext(DbContextOptions<ArtecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ARTEC;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("Pk_IdPais");

            entity.ToTable("Pais", "Desmodus");

            entity.Property(e => e.Nombre).HasMaxLength(60);
            entity.Property(e => e.NombreCorto).HasMaxLength(5);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("Pk_IdPersona");

            entity.ToTable("Persona", "Desmodus");

            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(60);
            entity.Property(e => e.NroDocumento)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.PrimerApellido)
                .IsRequired()
                .HasMaxLength(60);
            entity.Property(e => e.SegundoApellido).HasMaxLength(60);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Persona_Pais");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
