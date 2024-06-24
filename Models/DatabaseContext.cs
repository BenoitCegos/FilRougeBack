using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.Models;

public partial class FilRougeContext : DbContext
{
    public FilRougeContext()
    {
    }

    public FilRougeContext(DbContextOptions<FilRougeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Liste> Listes { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<Tache> Taches { get; set; }

    public virtual DbSet<User> Users { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.ToTable("Commentaire");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenu).HasColumnName("contenu");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.TacheId)
                .HasColumnType("INT")
                .HasColumnName("tache_id");

            entity.HasOne(d => d.Tache).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.TacheId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Liste>(entity =>
        {
            entity.ToTable("Liste");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");
            entity.Property(e => e.ProjetId)
                .HasColumnType("INT")
                .HasColumnName("projet_id");

            entity.HasOne(d => d.Projet).WithMany(p => p.Listes)
                .HasForeignKey(d => d.ProjetId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.ToTable("Projet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.ToTable("Tache");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("endDate");
            entity.Property(e => e.ListeId)
                .HasColumnType("INT")
                .HasColumnName("liste_id");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");

            entity.HasOne(d => d.Liste).WithMany(p => p.Taches)
                .HasForeignKey(d => d.ListeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
