﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XUMHUB.DTOS;

#nullable disable

namespace XUMHUB.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XUMHUB.DTOS.Case", b =>
                {
                    b.Property<string>("Case1")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CASE");

                    b.ToTable("CASES");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Cpu", b =>
                {
                    b.Property<string>("Cpu1")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CPU");

                    b.ToTable("CPUS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.CustomerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChannelReference")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OrderId")
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasColumnName("OrderID")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK__Customer__3214EC27E1D2AD5B");

                    b.ToTable("CustomerInfo");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Gpu", b =>
                {
                    b.Property<string>("Gpu1")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("GPU");

                    b.ToTable("GPUS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Hdd", b =>
                {
                    b.Property<string>("Hdd1")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("HDD");

                    b.ToTable("HDDS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssignedNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("Unknown");

                    b.Property<string>("Channel")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength();

                    b.Property<DateOnly>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("IsTested")
                        .HasColumnType("bit");

                    b.Property<string>("Orderid")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("PackedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("Unknown");

                    b.Property<DateTime?>("PackedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Qty")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("QTY")
                        .IsFixedLength();

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SKU");

                    b.Property<string>("TestStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasDefaultValue("Unknown")
                        .IsFixedLength();

                    b.Property<string>("TestedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasDefaultValue("Not Tested")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK__History__3214EC07F5038045");

                    b.ToTable("History");
                });

            modelBuilder.Entity("XUMHUB.DTOS.LaptopModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Display")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaptopModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LaptopModels");
                });

            modelBuilder.Entity("XUMHUB.DTOS.ManifestTable", b =>
                {
                    b.Property<string>("OrderNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderSku")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("OrderSKU");

                    b.Property<DateTime?>("PackedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Prebuild")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrebuildSku")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("PrebuildSKU");

                    b.ToTable("ManifestTable");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Motherboard", b =>
                {
                    b.Property<string>("Motherboard1")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("MOTHERBOARD");

                    b.ToTable("MOTHERBOARDS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ponumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PONumber");

                    b.Property<string>("Potitle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("POTitle");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SKU");

                    b.HasKey("Id")
                        .HasName("PK__Purchase__3214EC0798DA2276");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Qcresult", b =>
                {
                    b.Property<int>("QcresultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QCResultId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QcresultId"));

                    b.Property<bool?>("BatteryTestPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("CableManagementPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("CameraTestPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("ChargerTestPassed")
                        .HasColumnType("bit");

                    b.Property<string>("DbId")
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .IsFixedLength();

                    b.Property<bool?>("IotestPassed")
                        .HasColumnType("bit")
                        .HasColumnName("IOTestPassed");

                    b.Property<bool?>("KeyboardTestPassed")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<bool?>("PixelTest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<DateTime?>("QctestDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("QCTestDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("RgbAndLightsPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("SoundTestPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("StressTestPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("TouchpadTestPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("Verdict")
                        .HasColumnType("bit");

                    b.Property<bool?>("WifiTest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("QcresultId")
                        .HasName("PK__QCResult__5ED0A44F957CCB4C");

                    b.ToTable("QCResults");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Ramsize", b =>
                {
                    b.Property<string>("Size")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.ToTable("RAMSizes");
                });

            modelBuilder.Entity("XUMHUB.DTOS.ReplacedPart", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartId"));

                    b.Property<string>("PartName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PartSku")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("PartSKU");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ReturnId")
                        .HasColumnType("int");

                    b.HasKey("PartId")
                        .HasName("PK__Replaced__7C3F0D50DBC6DDCC");

                    b.HasIndex("ReturnId");

                    b.ToTable("ReplacedParts");
                });

            modelBuilder.Entity("XUMHUB.DTOS.ReturnsInfo", b =>
                {
                    b.Property<int>("ReturnId")
                        .HasColumnType("int");

                    b.Property<string>("AdditionalRepairInfo")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalReturnInfo")
                        .HasColumnType("text");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasColumnName("OrderID")
                        .IsFixedLength();

                    b.Property<string>("ReasonForReturn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ReturnId")
                        .HasName("PK__ReturnsI__F445E9A890990FE8");

                    b.ToTable("ReturnsInfo");
                });

            modelBuilder.Entity("XUMHUB.DTOS.ServiceTag", b =>
                {
                    b.Property<string>("Model")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("ServiceKey")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.ToTable("ServiceTags");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Sku", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Case")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("CASE")
                        .IsFixedLength();

                    b.Property<string>("Cpu")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("CPU")
                        .IsFixedLength();

                    b.Property<string>("Gpu")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("GPU")
                        .IsFixedLength();

                    b.Property<string>("Hdd")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("HDD")
                        .IsFixedLength();

                    b.Property<string>("Mobo")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("MOBO")
                        .IsFixedLength();

                    b.Property<string>("Ram")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .HasColumnName("RAM")
                        .IsFixedLength();

                    b.Property<string>("Sku1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SKU");

                    b.Property<string>("Ssd")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("SSD")
                        .IsFixedLength();

                    b.Property<string>("Windows")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasDefaultValue("Windows 11 Home")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("SKUS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Skuview", b =>
                {
                    b.Property<string>("Case")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("CASE")
                        .IsFixedLength();

                    b.Property<string>("Cpu")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("CPU")
                        .IsFixedLength();

                    b.Property<string>("Gpu")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("GPU")
                        .IsFixedLength();

                    b.Property<string>("Hdd")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("HDD")
                        .IsFixedLength();

                    b.Property<string>("Mobo")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("MOBO")
                        .IsFixedLength();

                    b.Property<string>("Ram")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .HasColumnName("RAM")
                        .IsFixedLength();

                    b.Property<string>("Sku")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SKU");

                    b.Property<string>("Ssd")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("SSD")
                        .IsFixedLength();

                    b.ToTable((string)null);

                    b.ToView("SKUview", (string)null);
                });

            modelBuilder.Entity("XUMHUB.DTOS.Ssd", b =>
                {
                    b.Property<string>("Ssd1")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SSD");

                    b.ToTable("SSDS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.StaffTable", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<int?>("StaffNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TestingPower")
                        .HasColumnType("int");

                    b.ToTable("StaffTable");
                });

            modelBuilder.Entity("XUMHUB.DTOS.TestResult", b =>
                {
                    b.Property<int>("TestResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestResultId"));

                    b.Property<string>("BatteryLife")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<decimal?>("CpumaxTemp")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("CPUMaxTemp");

                    b.Property<string>("DbId")
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .IsFixedLength();

                    b.Property<int?>("ErrorCount")
                        .HasColumnType("int");

                    b.Property<decimal?>("GpumaxTemp")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("GPUMaxTemp");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("WheaErrorCount")
                        .HasColumnType("int");

                    b.HasKey("TestResultId")
                        .HasName("PK__TestResu__E24635876C73A7A8");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("XUMHUB.DTOS.Window", b =>
                {
                    b.Property<string>("Windows")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("WINDOWS");

                    b.ToTable("WINDOWS");
                });

            modelBuilder.Entity("XUMHUB.DTOS.WindowsKeyDatum", b =>
                {
                    b.Property<string>("ServiceTag")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Agent")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cpu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CPU");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActivated")
                        .HasColumnType("bit")
                        .HasColumnName("isActivated");

                    b.Property<string>("Sku")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SKU");

                    b.Property<string>("WindowsKey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WindowsVersion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServiceTag")
                        .HasName("PK__WindowsK__71080053B0244076");

                    b.ToTable("WindowsKeyData");
                });

            modelBuilder.Entity("XUMHUB.DTOS.ReplacedPart", b =>
                {
                    b.HasOne("XUMHUB.DTOS.ReturnsInfo", "Return")
                        .WithMany("ReplacedParts")
                        .HasForeignKey("ReturnId")
                        .HasConstraintName("FK__ReplacedP__Retur__4F47C5E3");

                    b.Navigation("Return");
                });

            modelBuilder.Entity("XUMHUB.DTOS.ReturnsInfo", b =>
                {
                    b.Navigation("ReplacedParts");
                });
#pragma warning restore 612, 618
        }
    }
}