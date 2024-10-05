using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRealEstate.DataLayer.Migrations
{
    public partial class InitialDatabase9803102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstateStatusId",
                table: "Estates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstateStatuses",
                columns: table => new
                {
                    EstateStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateStatuses", x => x.EstateStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_EstateStatusId",
                table: "Estates",
                column: "EstateStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_EstateStatuses_EstateStatusId",
                table: "Estates",
                column: "EstateStatusId",
                principalTable: "EstateStatuses",
                principalColumn: "EstateStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_EstateStatuses_EstateStatusId",
                table: "Estates");

            migrationBuilder.DropTable(
                name: "EstateStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Estates_EstateStatusId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "EstateStatusId",
                table: "Estates");
        }
    }
}
