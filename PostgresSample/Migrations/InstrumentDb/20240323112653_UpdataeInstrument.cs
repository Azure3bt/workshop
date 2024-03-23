using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresSample.Migrations.InstrumentDb
{
    /// <inheritdoc />
    public partial class UpdataeInstrument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bourse",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Class",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassChanel",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupState",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HiddenPriceType",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Segment",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SettlementType",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "basicInfo.v2",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bourse",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "Class",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "ClassChanel",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "GroupState",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "HiddenPriceType",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "Segment",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "SettlementType",
                schema: "basicInfo.v2",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "basicInfo.v2",
                table: "Instrument");
        }
    }
}
