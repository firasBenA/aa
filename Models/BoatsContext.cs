using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Models;

public partial class BoatsContext : DbContext
{
   

    public BoatsContext(DbContextOptions<BoatsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boat> Boats { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Facture> Factures { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boat>(entity =>
        {
            entity.ToTable("Boat");

            entity.Property(e => e.Availability)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEquipmentsNavigation).WithMany(p => p.Boats)
                .HasForeignKey(d => d.IdEquipments)
                .HasConstraintName("FK_Boat_Equipments");

            entity.HasOne(d => d.IdFeedBackNavigation).WithMany(p => p.Boats)
                .HasForeignKey(d => d.IdFeedBack)
                .HasConstraintName("FK_Boat_FeedBack");

            entity.HasOne(d => d.IdReservationNavigation).WithMany(p => p.Boats)
                .HasForeignKey(d => d.IdReservation)
                .HasConstraintName("FK_Boat_Reservation");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.ToTable("Chat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Message)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Facture>(entity =>
        {
            entity.ToTable("Facture");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Prix).HasColumnName("prix");
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.ToTable("FeedBack");

            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservation");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.IdFactureNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdFacture)
                .HasConstraintName("FK_Reservation_Facture");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
