using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;

public partial class MicrofinanzaContext : DbContext
{
    public MicrofinanzaContext()
    {
    }

    public MicrofinanzaContext(DbContextOptions<MicrofinanzaContext> options)
        : base(options)
    {
    }


    public virtual DbSet<TbPersonaNatural> TbPersonaNaturals { get; set; }

    public virtual DbSet<TbTipoDocumento> TbTipoDocumentos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LEO; Database=Microfinanza; TrustServerCertificate=True; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbPersonaNatural>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__tb_Perso__A47881413E7D26BA");

            entity.ToTable("tb_PersonaNatural");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.LugarNacimiento)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("lugarNacimiento");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.PaisResidencia)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("paisResidencia");
        });

        modelBuilder.Entity<TbTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__tb_TipoD__61FDF9F59373AC80");

            entity.ToTable("tb_TipoDocumento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.CDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cDescripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
