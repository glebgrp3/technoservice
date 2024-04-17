using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ООО_Техносервис.neModel;

public partial class Demoexm1Context : DbContext
{
    public static Demoexm1Context _context { get; } = new Demoexm1Context();
    public Demoexm1Context()
    {
    }

    public Demoexm1Context(DbContextOptions<Demoexm1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Equipmenttype> Equipmenttypes { get; set; }

    public virtual DbSet<Repairequipment> Repairequipments { get; set; }

    public virtual DbSet<Repairrequest> Repairrequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Statusrepair> Statusrepairs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=12345;database=demoexm1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.IdEquipment).HasName("PRIMARY");

            entity.ToTable("equipments");

            entity.HasIndex(e => e.TypeEquipment, "types_idx");

            entity.Property(e => e.IdEquipment).ValueGeneratedNever();
            entity.Property(e => e.CauseEquipment).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.NameEquipment).HasMaxLength(255);
            entity.Property(e => e.SeriaEquipment).HasMaxLength(255);

            entity.HasOne(d => d.TypeEquipmentNavigation).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.TypeEquipment)
                .HasConstraintName("types");
        });

        modelBuilder.Entity<Equipmenttype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("equipmenttypes");

            entity.Property(e => e.TypeId).ValueGeneratedNever();
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Repairequipment>(entity =>
        {
            entity.HasKey(e => e.IdRepairEquipment).HasName("PRIMARY");

            entity.ToTable("repairequipments");

            entity.HasIndex(e => e.Executor, "Executor");

            entity.HasIndex(e => e.IdEquipment, "IdEquipment");

            entity.HasIndex(e => e.IdRepair, "IdRepair");

            entity.HasIndex(e => e.Status, "repairequipments_ibfk_4_idx");

            entity.Property(e => e.IdRepairEquipment).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Cost).HasPrecision(10, 2);

            entity.HasOne(d => d.ExecutorNavigation).WithMany(p => p.Repairequipments)
                .HasForeignKey(d => d.Executor)
                .HasConstraintName("repairequipments_ibfk_3");

            entity.HasOne(d => d.IdEquipmentNavigation).WithMany(p => p.Repairequipments)
                .HasForeignKey(d => d.IdEquipment)
                .HasConstraintName("repairequipments_ibfk_2");

            entity.HasOne(d => d.IdRepairNavigation).WithMany(p => p.Repairequipments)
                .HasForeignKey(d => d.IdRepair)
                .HasConstraintName("repairequipments_ibfk_1");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Repairequipments)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("repairequipments_ibfk_4");
        });

        modelBuilder.Entity<Repairrequest>(entity =>
        {
            entity.HasKey(e => e.IdRepairRequest).HasName("PRIMARY");

            entity.ToTable("repairrequests");

            entity.HasIndex(e => e.IdClient, "IdClient");

            entity.Property(e => e.IdRepairRequest).ValueGeneratedNever();
            entity.Property(e => e.Priority).HasMaxLength(50);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Repairrequests)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("repairrequests_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Statusrepair>(entity =>
        {
            entity.HasKey(e => e.IdStatusRepairs).HasName("PRIMARY");

            entity.ToTable("statusrepairs");

            entity.Property(e => e.IdStatusRepairs).ValueGeneratedNever();
            entity.Property(e => e.StatusName).HasMaxLength(45);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleId, "roles_idx");

            entity.Property(e => e.IdUser).ValueGeneratedNever();
            entity.Property(e => e.LoginUser).HasMaxLength(100);
            entity.Property(e => e.NameUser).HasMaxLength(100);
            entity.Property(e => e.PasswordUser).HasMaxLength(255);
            entity.Property(e => e.SurNameUser).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
