using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeakerSop.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyPostOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberPostOffice",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberPostOffice",
                table: "Orders");
        }
    }
}
