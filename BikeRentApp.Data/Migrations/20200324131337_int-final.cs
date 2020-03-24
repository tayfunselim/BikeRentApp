using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentApp.Data.Migrations
{
    public partial class intfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountBuy",
                table: "Memberships",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiscountRent",
                table: "Memberships",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MembershipType",
                table: "Memberships",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountBuy",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "DiscountRent",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "Memberships");
        }
    }
}
