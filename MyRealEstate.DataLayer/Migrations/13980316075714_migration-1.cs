using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRealEstate.DataLayer.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstateContracts",
                columns: table => new
                {
                    EstateContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerUserId = table.Column<string>(nullable: true),
                    BuyerUserId = table.Column<string>(nullable: true),
                    SellerUserId = table.Column<string>(nullable: true),
                    EstateId = table.Column<int>(nullable: false),
                    SaveTime = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateContracts", x => x.EstateContractId);
                    table.ForeignKey(
                        name: "FK_EstateContracts_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestEstates",
                columns: table => new
                {
                    RequestEstateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaveUserId = table.Column<string>(nullable: true),
                    EstateId = table.Column<int>(nullable: false),
                    SaveTime = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestEstates", x => x.RequestEstateId);
                    table.ForeignKey(
                        name: "FK_RequestEstates_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateContracts_EstateId",
                table: "EstateContracts",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestEstates_EstateId",
                table: "RequestEstates",
                column: "EstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateContracts");

            migrationBuilder.DropTable(
                name: "RequestEstates");
        }
    }
}
