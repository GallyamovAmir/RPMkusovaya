using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RPM.Models;

public partial class RpmAmirContext : DbContext
{
    public RpmAmirContext()
    {
    }

    public RpmAmirContext(DbContextOptions<RpmAmirContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=RpmAmir;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC0739AF5CB3");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobTitle__3214EC0725DAEDD3");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC078C699E30");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC07D5DC8BEE");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Client).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tickets__ClientI__70A8B9AE");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK__Tickets__State__6FB49575");

            entity.HasOne(d => d.Train).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Tickets__TrainId__6EC0713C");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK__Tickets__Type__6DCC4D03");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trains__3214EC0783EFE7A1");

            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");

            entity.HasOne(d => d.Arrival).WithMany(p => p.TrainArrivals)
                .HasForeignKey(d => d.ArrivalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trains__ArrivalI__69FBBC1F");

            entity.HasOne(d => d.Departure).WithMany(p => p.TrainDepartures)
                .HasForeignKey(d => d.DepartureId)
                .HasConstraintName("FK__Trains__Departur__6AEFE058");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Types__3214EC0758C68F1A");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F508FB03");

            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workers__3214EC078BDC361D");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.Workers)
                .HasForeignKey(d => d.JobTitleId)
                .HasConstraintName("FK__Workers__JobTitl__6166761E");

            entity.HasOne(d => d.User).WithMany(p => p.Workers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Workers__UserId__607251E5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
