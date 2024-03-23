using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresSample.Migrations.InstrumentDb
{
    /// <inheritdoc />
    public partial class SqlInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "basicInfo.v2");

            migrationBuilder.CreateTable(
                name: "Instrument",
                schema: "basicInfo.v2",
                columns: table => new
                {
                    InstrumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TSETMCID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardCode = table.Column<long>(type: "bigint", nullable: false),
                    BoardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSectorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AskMaxQuantity = table.Column<long>(type: "bigint", nullable: true),
                    BidMaxQuantity = table.Column<long>(type: "bigint", nullable: true),
                    MaxQuantity = table.Column<long>(type: "bigint", nullable: true),
                    MinQuantity = table.Column<long>(type: "bigint", nullable: true),
                    Tick = table.Column<long>(type: "bigint", nullable: true),
                    Lot = table.Column<long>(type: "bigint", nullable: true),
                    BaseVolume = table.Column<long>(type: "bigint", nullable: true),
                    ParValue = table.Column<long>(type: "bigint", nullable: true),
                    ProductTypeCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTypeCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PriceMin = table.Column<long>(type: "bigint", nullable: false),
                    PriceMax = table.Column<long>(type: "bigint", nullable: false),
                    AskFeeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidFeeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HiddenPrice = table.Column<long>(type: "bigint", nullable: true),
                    HiddenPriceFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HiddenPriceTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBidPermitted = table.Column<bool>(type: "bit", nullable: false),
                    IsAskPermitted = table.Column<bool>(type: "bit", nullable: false),
                    IsSearchPermitted = table.Column<bool>(type: "bit", nullable: false),
                    PutOptionParentInstrumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PutOptionParentInstrumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PutOptionParentInstrumentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PutOptionPerformDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewInstrumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewInstrumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewInstrumentText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentUpdaterLog",
                schema: "basicInfo.v2",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KafkaMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentUpdaterLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrument",
                schema: "basicInfo.v2");

            migrationBuilder.DropTable(
                name: "InstrumentUpdaterLog",
                schema: "basicInfo.v2");
        }
    }
}
