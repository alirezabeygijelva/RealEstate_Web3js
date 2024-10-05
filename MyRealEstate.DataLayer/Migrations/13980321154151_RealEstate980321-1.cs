using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRealEstate.DataLayer.Migrations
{
    public partial class RealEstate9803211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SaveTime",
                table: "EstateContracts",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "BuyerOK",
                table: "EstateContracts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyerOKTime",
                table: "EstateContracts",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SellerOK",
                table: "EstateContracts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SellerOKTime",
                table: "EstateContracts",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerOK",
                table: "EstateContracts");

            migrationBuilder.DropColumn(
                name: "BuyerOKTime",
                table: "EstateContracts");

            migrationBuilder.DropColumn(
                name: "SellerOK",
                table: "EstateContracts");

            migrationBuilder.DropColumn(
                name: "SellerOKTime",
                table: "EstateContracts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SaveTime",
                table: "EstateContracts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }
    }
}
