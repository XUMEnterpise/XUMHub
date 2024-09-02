using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutoPilotTest> AutoPilotTests { get; set; }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<Cpu> Cpus { get; set; }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<Fault> Faults { get; set; }

    public virtual DbSet<Gpu> Gpus { get; set; }

    public virtual DbSet<Hdd> Hdds { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<InventoryBin> InventoryBins { get; set; }

    public virtual DbSet<IssueLog> IssueLogs { get; set; }

    public virtual DbSet<LaptopModels> LaptopModels { get; set; }

    public virtual DbSet<Lot> Lots { get; set; }

    public virtual DbSet<ManifestTable> ManifestTables { get; set; }

    public virtual DbSet<ModelToBin> ModelToBins { get; set; }

    public virtual DbSet<Motherboard> Motherboards { get; set; }

    public virtual DbSet<Qccheck> Qcchecks { get; set; }

    public virtual DbSet<Qcdatum> Qcdata { get; set; }

    public virtual DbSet<Qcentry> Qcentries { get; set; }

    public virtual DbSet<Qcresult> Qcresults { get; set; }

    public virtual DbSet<Ramsize> Ramsizes { get; set; }

    public virtual DbSet<RepairDatum> RepairData { get; set; }

    public virtual DbSet<ReplacedPart> ReplacedParts { get; set; }

    public virtual DbSet<ReturnsInfo> ReturnsInfos { get; set; }

    public virtual DbSet<ServiceTag> ServiceTags { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<Skuview> Skuviews { get; set; }

    public virtual DbSet<Ssd> Ssds { get; set; }

    public virtual DbSet<StaffTable> StaffTables { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<Window> Windows { get; set; }

    public virtual DbSet<WindowsKeyDatum> WindowsKeyData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source=DESKTOP-V7HB0MU\\MSSQLSERVER01;Initial Catalog=xumlocal;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=True");
        => optionsBuilder.UseSqlServer("Data Source=WIN-K1TRUVHT0PC\\XUMGPC;Initial Catalog=xumlocal;Persist Security Info=True;User ID=XumAdmin;Password=Lolipopchainsaw3;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27E1D2AD5B");

            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<Fault>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faults__3214EC07EBEDAC4C");

            entity.HasOne(d => d.Repair).WithMany(p => p.Faults).HasConstraintName("FK_Faults_RepairData");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC07F5038045");

            entity.Property(e => e.AssignedNumber).HasDefaultValue("Unknown");
            entity.Property(e => e.Channel).IsFixedLength();
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsRecovered).HasDefaultValue(false);
            entity.Property(e => e.Orderid).IsFixedLength();
            entity.Property(e => e.PackedBy).HasDefaultValue("Unknown");
            entity.Property(e => e.Qty).IsFixedLength();
            entity.Property(e => e.TestStatus)
                .HasDefaultValue("Unknown")
                .IsFixedLength();
            entity.Property(e => e.TestedBy)
                .HasDefaultValue("Not Tested")
                .IsFixedLength();
        });

        modelBuilder.Entity<InventoryBin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC0752904E24");
        });

        modelBuilder.Entity<IssueLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueLog__3214EC2734A96D96");
        });

        modelBuilder.Entity<LaptopModels>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LaptopMo__3214EC07285D7582");
        });

        modelBuilder.Entity<ManifestTable>(entity =>
        {
            entity.Property(e => e.PackedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ModelToBin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ModelToB__3214EC071B2B5799");
        });

        modelBuilder.Entity<Qccheck>(entity =>
        {
            entity.HasKey(e => e.CheckId).HasName("PK__QCChecks__868157665B6BB8A1");
        });

        modelBuilder.Entity<Qcdatum>(entity =>
        {
            entity.HasKey(e => e.Qcid).HasName("PK__QCData__DC29BFB24B868AC6");

            entity.HasOne(d => d.Db).WithMany(p => p.Qcdata)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QCData_History");
        });

        modelBuilder.Entity<Qcentry>(entity =>
        {
            entity.HasKey(e => e.Qcid).HasName("PK__QCEntry__DC29BFB2B2F194FA");
        });

        modelBuilder.Entity<Qcresult>(entity =>
        {
            entity.HasKey(e => e.QcresultId).HasName("PK__QCResult__5ED0A44F957CCB4C");

            entity.Property(e => e.DbId).IsFixedLength();
            entity.Property(e => e.PixelTest).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.QctestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.WifiTest).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<RepairDatum>(entity =>
        {
            entity.HasKey(e => e.RepairId).HasName("PK__RepairDa__07D0BC2D39218AEE");
        });

        modelBuilder.Entity<ReplacedPart>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Replaced__7C3F0D50DBC6DDCC");

            entity.HasOne(d => d.Return).WithMany(p => p.ReplacedParts).HasConstraintName("FK__ReplacedP__Retur__4F47C5E3");
        });

        modelBuilder.Entity<ReturnsInfo>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__ReturnsI__F445E9A890990FE8");

            entity.Property(e => e.ReturnId).ValueGeneratedNever();
            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.Property(e => e.Case).IsFixedLength();
            entity.Property(e => e.Cpu).IsFixedLength();
            entity.Property(e => e.Gpu).IsFixedLength();
            entity.Property(e => e.Hdd).IsFixedLength();
            entity.Property(e => e.Mobo).IsFixedLength();
            entity.Property(e => e.Ram).IsFixedLength();
            entity.Property(e => e.Ssd).IsFixedLength();
            entity.Property(e => e.Windows)
                .HasDefaultValue("Windows 11 Home")
                .IsFixedLength();
        });

        modelBuilder.Entity<Skuview>(entity =>
        {
            entity.ToView("SKUview");

            entity.Property(e => e.Case).IsFixedLength();
            entity.Property(e => e.Cpu).IsFixedLength();
            entity.Property(e => e.Gpu).IsFixedLength();
            entity.Property(e => e.Hdd).IsFixedLength();
            entity.Property(e => e.Mobo).IsFixedLength();
            entity.Property(e => e.Ram).IsFixedLength();
            entity.Property(e => e.Ssd).IsFixedLength();
        });

        modelBuilder.Entity<StaffTable>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.TestResultId).HasName("PK__TestResu__E24635876C73A7A8");

            entity.Property(e => e.BatteryLife).IsFixedLength();
        });

        modelBuilder.Entity<WindowsKeyDatum>(entity =>
        {
            entity.HasKey(e => e.ServiceTag).HasName("PK__WindowsK__710800538A1A145B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
