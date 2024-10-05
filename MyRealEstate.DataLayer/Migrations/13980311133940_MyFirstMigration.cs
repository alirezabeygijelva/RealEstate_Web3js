using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRealEstate.DataLayer.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CellphoneNo = table.Column<string>(maxLength: 11, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    EthAccountAddress = table.Column<string>(maxLength: 100, nullable: true),
                    FName = table.Column<string>(maxLength: 50, nullable: false),
                    IsConsultant = table.Column<bool>(nullable: false),
                    LName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    PostalAddress = table.Column<string>(maxLength: 500, nullable: true),
                    RegDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });
        }
    }
}
