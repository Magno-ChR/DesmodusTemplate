using System;
using System.Collections.Generic;
using DesmodusTemplate.Entities.Artec;
using Microsoft.EntityFrameworkCore;

namespace DesmodusTemplate.Data;

public partial class HomeContext : DbContext
{
    public HomeContext()
    {
    }

    public HomeContext(DbContextOptions<HomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HOME;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1BD0C9212");

            entity.Property(e => e.IdEstado).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__FC850A7B66B7C981");

            entity.Property(e => e.Gentilicio)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreCorto)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__2EC8D2AC15894B44");

            entity.Property(e => e.Celular)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionResidencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("fk_Persona_Estado");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("fk_Persona_Pais");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
