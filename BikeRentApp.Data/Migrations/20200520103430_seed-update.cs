using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentApp.Data.Migrations
{
    public partial class seedupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "Gender", "LastName", "MembershipId", "PhoneNumber" },
                values: new object[] { 14, 57, 1, "mogo@hotmail.com", "Monika", 2, "Gogo", 2, "071-371042" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
