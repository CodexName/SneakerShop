using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeakerSop.Migrations.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class AddPropertyBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "RequisitesUsers");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "RequisitesUsers",
                newName: "Date");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "RequisitesUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "RequisitesUsers");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "RequisitesUsers",
                newName: "Month");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "RequisitesUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
