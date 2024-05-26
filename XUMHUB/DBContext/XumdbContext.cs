using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XUMHUB.DTOS;

namespace XUMHUB.DBContext;

public partial class XumdbContext : DbContext
{
    public XumdbContext()
    {
    }

    public XumdbContext(DbContextOptions<XumdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Qcresult> Qcresults { get; set; }

    public virtual DbSet<ReplacedPart> ReplacedParts { get; set; }

    public virtual DbSet<ReturnsInfo> ReturnsInfos { get; set; }

    public virtual DbSet<ServiceTag> ServiceTags { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<StaffTable> StaffTables { get; set; }

    public virtual DbSet<Staging> Stagings { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FDI3A84;Initial Catalog=XUMDB;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC2732AEBA73");

            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC072443CC90");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsTested).HasDefaultValue(false);
            entity.Property(e => e.OrderId).IsFixedLength();
            entity.Property(e => e.TestStatus).HasDefaultValue("N/A");
            entity.Property(e => e.TestedBy).HasDefaultValue("N/A");
        });

        modelBuilder.Entity<Qcresult>(entity =>
        {
            entity.HasKey(e => e.QcresultId).HasName("PK__QCResult__5ED0A44F50F6D8F5");

            entity.Property(e => e.DbId).IsFixedLength();
        });

        modelBuilder.Entity<ReplacedPart>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Replaced__7C3F0D50428B4356");

            entity.HasOne(d => d.Return).WithMany(p => p.ReplacedParts).HasConstraintName("FK__ReplacedP__Retur__10566F31");
        });

        modelBuilder.Entity<ReturnsInfo>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__ReturnsI__F445E9A81FD759BF");

            entity.Property(e => e.ReturnId).ValueGeneratedNever();
            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SKUS__3214EC071F107B5D");
        });

        modelBuilder.Entity<StaffTable>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<Staging>(entity =>
        {
            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.TestResultId).HasName("PK__TestResu__E2463587F843604D");

            entity.Property(e => e.BatteryLife).IsFixedLength();
            entity.Property(e => e.DbId).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
