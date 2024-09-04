using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrintPostALPL.Context.Models;

public partial class PrintPostAlplContext : DbContext
{
    public PrintPostAlplContext()
    {
    }

    public PrintPostAlplContext(DbContextOptions<PrintPostAlplContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Affranchissement> Affranchissements { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<Encre> Encres { get; set; }

    public virtual DbSet<Enveloppe> Enveloppes { get; set; }

    public virtual DbSet<Feuille> Feuilles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=WINDOWS;Database=PrintPostALPL;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Affranchissement>(entity =>
        {
            entity.HasKey(e => e.IdAffranchissement).HasName("PK__Affranch__11BD0C4C9B576F25");

            entity.ToTable("Affranchissement");

            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Prix20gOuMoins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prix20gOuMoins");
            entity.Property(e => e.PrixPlus20g)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prixPlus20g");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__C1961B33BEF3B8A5");

            entity.ToTable("Client");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MntPenalite)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("mntPenalite");
            entity.Property(e => e.RaisonSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("raisonSocial");
            entity.Property(e => e.Siret)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("siret");
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.IdCommande).HasName("PK__Commande__6828586C377627A1");

            entity.ToTable("Commande");

            entity.Property(e => e.DateCreation).HasColumnName("dateCreation");
            entity.Property(e => e.DateDepotReel).HasColumnName("dateDepotReel");
            entity.Property(e => e.DateDepotSouhaite).HasColumnName("dateDepotSouhaite");
            entity.Property(e => e.MntDevise)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mntDevise");
            entity.Property(e => e.MntFacture)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mntFacture");
            entity.Property(e => e.NbrCourriers).HasColumnName("nbrCourriers");
            entity.Property(e => e.NbrFeuillets).HasColumnName("nbrFeuillets");

            entity.HasOne(d => d.IdAffranchissementNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdAffranchissement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commande__IdAffr__412EB0B6");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commande__IdClie__44FF419A");

            entity.HasOne(d => d.IdEncreNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdEncre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commande__IdEncr__4316F928");

            entity.HasOne(d => d.IdEnveloppeNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdEnveloppe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commande__IdEnve__4222D4EF");

            entity.HasOne(d => d.IdFeuilleNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdFeuille)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commande__IdFeui__440B1D61");
        });

        modelBuilder.Entity<Encre>(entity =>
        {
            entity.HasKey(e => e.IdEncre).HasName("PK__Encre__A16FFE6DA4CE84A9");

            entity.ToTable("Encre");

            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("prix");
        });

        modelBuilder.Entity<Enveloppe>(entity =>
        {
            entity.HasKey(e => e.IdEnveloppe).HasName("PK__Envelopp__9A651F99408D4FF2");

            entity.ToTable("Enveloppe");

            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Poids)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("poids");
            entity.Property(e => e.Prix)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("prix");
            entity.Property(e => e.Taille)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taille");
        });

        modelBuilder.Entity<Feuille>(entity =>
        {
            entity.HasKey(e => e.IdFeuille).HasName("PK__Feuille__212EC20B60107874");

            entity.ToTable("Feuille");

            entity.Property(e => e.Epaisseur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("epaisseur");
            entity.Property(e => e.Poids)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("poids");
            entity.Property(e => e.Prix)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prix");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
