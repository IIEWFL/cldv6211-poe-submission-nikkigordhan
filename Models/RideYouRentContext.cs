using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CLDV6221_PoE_Part3.Models;

public partial class RideYouRentContext : DbContext
{
    public RideYouRentContext()
    {
    }

    public RideYouRentContext(DbContextOptions<RideYouRentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Car { get; set; }

    public virtual DbSet<CarBodyType> CarBodyTypes { get; set; }

    public virtual DbSet<CarMake> CarMakes { get; set; }

    public virtual DbSet<Driver> Driver { get; set; }

    public virtual DbSet<Inspector> Inspector { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<TblRental> TblRental { get; set; }

    public virtual DbSet<TblReturn> TblReturn { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=NIKKI-PC;Initial Catalog=RideYouRent;Integrated Security=True;Encrypt=False");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //     => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RideYouRent3;Integrated Security=True;Encrypt=False");
            => optionsBuilder.UseSqlServer("name=ConnectionStrings:CLDV6221_PoE_Part3Context");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //the format of the foreign and primary keys was taken and adpated from Microsoft.
        //https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
        //there are 12 contributors

        //the modelBuilder helps me create tables with primary and foreign keys.

        modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId).HasName("PK__Car__68A0342E38A4EF59");

                entity.ToTable("Car");

                entity.Property(e => e.CarNo)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.Model)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarBodyType).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarBodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Car_Body_Type_fk");

                entity.HasOne(d => d.CarMake).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarMakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Car_Make_ID_fk");
            });

            modelBuilder.Entity<CarBodyType>(entity =>
            {
                entity.HasKey(e => e.CarBodyTypeId).HasName("PK__CarBodyT__2BA49ACB46C7FEFE");

                entity.ToTable("CarBodyType");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarMake>(entity =>
            {
                entity.HasKey(e => e.CarMakeId).HasName("PK__CarMake__A125EE5C23DC5CFE");

                entity.ToTable("CarMake");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.DriverId).HasName("PK__Driver__F1B1CD04A445F47D");

                entity.ToTable("Driver");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inspector>(entity =>
            {
                entity.HasKey(e => e.InspectorId).HasName("PK__Inpsector");
                entity.ToTable("Inspector");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.InspectorNo)
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoginId).HasName("PK__Login");
                entity.ToTable("Login");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");
                entity.Property(e => e.InspectorId).HasColumnName("InspectorID");
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Inspector).WithMany(p => p.Logins)
                    .HasForeignKey(d => d.InspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Login_Inspector_fk");
            });

            modelBuilder.Entity<TblRental>(entity =>
            {
                entity.HasKey(e => e.RentalId).HasName("PK__tblRenta__9D23A44637D0DC96");

                entity.ToTable("tblRental");

                entity.Property(e => e.RentalId).HasColumnName("Rental_ID");
                entity.Property(e => e.CarId).HasColumnName("Car_ID");
                entity.Property(e => e.DriverId).HasColumnName("Driver_ID");
                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");
                entity.Property(e => e.InspectorId).HasColumnName("Inspector_ID");
                entity.Property(e => e.RentalFee)
                    .HasColumnType("money")
                    .HasColumnName("Rental_Fee");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.HasOne(d => d.Car).WithMany(p => p.TblRental)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rental_Car_fk");

                entity.HasOne(d => d.Driver).WithMany(p => p.TblRental)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rental_Driver_fk");

                entity.HasOne(d => d.Inspector).WithMany(p => p.TblRental)
                    .HasForeignKey(d => d.InspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rental_Inspector_fk");
            });

            modelBuilder.Entity<TblReturn>(entity =>
            {
                entity.HasKey(e => e.ReturnId).HasName("PK__tblRetur__0F4F4C56E54193E3");

                entity.ToTable("tblReturn");

                entity.Property(e => e.ReturnId).HasColumnName("Return_ID");
                entity.Property(e => e.CarId).HasColumnName("Car_ID");
                entity.Property(e => e.DriverId).HasColumnName("Driver_ID");
                entity.Property(e => e.ElapsedDate).HasColumnName("Elapsed_Date");
                entity.Property(e => e.Fine).HasColumnType("money");
                entity.Property(e => e.InspectorId).HasColumnName("Inspector_ID");
                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("Return_Date");

                entity.HasOne(d => d.Car).WithMany(p => p.TblReturn)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Return_Car_fk");

                entity.HasOne(d => d.Driver).WithMany(p => p.TblReturn)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Return_Driver_fk");

                entity.HasOne(d => d.Inspector).WithMany(p => p.TblReturn)
                    .HasForeignKey(d => d.InspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Return_Inspector_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
