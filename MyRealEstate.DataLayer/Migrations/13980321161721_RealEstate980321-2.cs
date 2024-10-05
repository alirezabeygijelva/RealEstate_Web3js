using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRealEstate.DataLayer.Migrations
{
    public partial class RealEstate9803212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "EstateContracts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "EstateContracts");
        }
    }
}
