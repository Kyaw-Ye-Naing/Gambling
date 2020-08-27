﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gambling_Proj.Models
{
    public partial class Gambling_AppContext : DbContext
    {
        public Gambling_AppContext()
        {
        }

        public Gambling_AppContext(DbContextOptions<Gambling_AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFootballTeam> TblFootballTeam { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.105.121.13;Initial Catalog=Gambling_App;user id=sa;password=209851@ung");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblFootballTeam>(entity =>
            {
                entity.HasKey(e => e.FootballTeamId);

                entity.ToTable("tbl_footballTeam");

                entity.Property(e => e.FootballTeamId)
                    .HasColumnName("footballTeamId")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FootballTeam)
                    .HasColumnName("footballTeam")
                    .HasMaxLength(50);

                entity.Property(e => e.FootballTeamMyan)
                    .HasColumnName("footballTeamMyan")
                    .HasMaxLength(50);

                entity.Property(e => e.League).HasMaxLength(50);
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("tbl_role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discription)
                    .HasColumnName("discription")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbl_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lock).HasColumnName("lock");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(250);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
