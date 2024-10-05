using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRealEstate.DataLayer.Migrations
{
    public partial class InitialDatabase9803103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForRequest",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "ForSale",
                table: "Estates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForRequest",
                table: "Estates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ForSale",
                table: "Estates",
                nullable: false,
                defaultValue: false);
        }
    }
}
