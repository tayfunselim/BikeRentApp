using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentApp.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "City", "Gender" },
                values: new object[] { 35, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "City", "Gender" },
                values: new object[] { 23, 2, 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "Gender", "LastName", "MembershipId", "PhoneNumber" },
                values: new object[,]
                {
                    { 5, 33, 7, "svetles@hotmail.com", "Svetlana", 2, "Svetlovska", 2, "072-371059" },
                    { 6, 38, 6, "jolem@hotmail.com", "Jole", 2, "Mala", 1, "078-371359" },
                    { 8, 37, 1, "fato@hotmail.com", "Fatmir", 1, "Iseni", 2, "072-371042" }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "DiscountBuy", "DiscountRent", "MembershipType" },
                values: new object[] { 3, 0.10000000000000001, 0.10000000000000001, "Yellow" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "Gender", "LastName", "MembershipId", "PhoneNumber" },
                values: new object[] { 3, 28, 5, "petre@yahoo.com", "Petar", 1, "Petrovski", 3, "071-273057" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "Gender", "LastName", "MembershipId", "PhoneNumber" },
                values: new object[] { 4, 29, 5, "majap@gmail.com", "Maja", 2, "Petrovska", 3, "078-371957" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "Gender", "LastName", "MembershipId", "PhoneNumber" },
                values: new object[] { 7, 33, 3, "gorde@hotmail.com", "Gordana", 2, "Gorde", 3, "071-271059" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");
        }
    }
}
