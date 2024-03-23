﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostgresSample.SqlServer;

#nullable disable

namespace PostgresSample.Migrations.InstrumentDb
{
    [DbContext(typeof(InstrumentDbContext))]
    [Migration("20240323112653_UpdataeInstrument")]
    partial class UpdataeInstrument
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("basicInfo.v2")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PostgresSample.SqlServer.Instrument", b =>
                {
                    b.Property<string>("InstrumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AskFeeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("AskMaxQuantity")
                        .HasColumnType("bigint");

                    b.Property<long?>("BaseVolume")
                        .HasColumnType("bigint");

                    b.Property<decimal>("BidFeeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("BidMaxQuantity")
                        .HasColumnType("bigint");

                    b.Property<long>("BoardCode")
                        .HasColumnType("bigint");

                    b.Property<string>("BoardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Bourse")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("ClassChanel")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupState")
                        .HasColumnType("int");

                    b.Property<long?>("HiddenPrice")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("HiddenPriceFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HiddenPriceTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HiddenPriceType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAskPermitted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBidPermitted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSearchPermitted")
                        .HasColumnType("bit");

                    b.Property<string>("Isin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Lot")
                        .HasColumnType("bigint");

                    b.Property<long?>("MaxQuantity")
                        .HasColumnType("bigint");

                    b.Property<long?>("MinQuantity")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NewInstrumentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewInstrumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewInstrumentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParValue")
                        .HasColumnType("bigint");

                    b.Property<long>("PriceMax")
                        .HasColumnType("bigint");

                    b.Property<long>("PriceMin")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductTypeCode1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductTypeCode2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutOptionParentInstrumentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutOptionParentInstrumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutOptionParentInstrumentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PutOptionPerformDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SectorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Segment")
                        .HasColumnType("int");

                    b.Property<int?>("SettlementType")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("SubSectorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubSectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TSETMCID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Tick")
                        .HasColumnType("bigint");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instrument", "basicInfo.v2");
                });

            modelBuilder.Entity("PostgresSample.SqlServer.InstrumentUpdaterLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConsumerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KafkaMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InstrumentUpdaterLog", "basicInfo.v2");
                });
#pragma warning restore 612, 618
        }
    }
}
