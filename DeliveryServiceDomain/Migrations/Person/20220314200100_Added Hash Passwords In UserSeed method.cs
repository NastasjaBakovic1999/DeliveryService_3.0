using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations.Person
{
    public partial class AddedHashPasswordsInUserSeedmethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8e5909b-4481-49bd-a81d-3cbf55f60272", "AQAAAAEAACcQAAAAEGF6S4bGQU27PZVFIWkIi0FZh8sUmTN7V7Ui3kFuFOatpvgr0Kfe4ZFnM/EE6C+RLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2dff604f-e894-485b-9675-991483c4d4fe", "AQAAAAEAACcQAAAAEL6uzeGFU1InQXXMf9QiMMGeuImCZo8h4UEDxuNbfqCjrZNfGvISyJK0RtmX73lF4w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2dea516-5cb2-41ef-a005-b839a916a409", "AQAAAAEAACcQAAAAEPiK+JCv+QaguOIHCTiJODZPCN3/QfgmMwDHC+btYfLFA+BivAcScXID5xy/Qcf+rQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8427e813-ffba-4255-9424-c6209693d474", "AQAAAAEAACcQAAAAEBSLfNN+9pYvAREDciBWB7q7JRDmsBZ4BJx/dEbr+nnMihbeGuPX3SQrpcQAlgEDFg==" });

            migrationBuilder.UpdateData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1",
                column: "NormalizedName",
                value: "USER");

            migrationBuilder.UpdateData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2",
                column: "NormalizedName",
                value: "DELIVERER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e21747d3-ce66-4c57-a053-4674f22628b5", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a82ebfa-0bb3-4556-84bb-e79351813844", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91e1e427-45a4-458f-a9d9-e4f9376107af", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f47e01a7-1f5a-4b9b-a9fe-aae251d776be", null });

            migrationBuilder.UpdateData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1",
                column: "NormalizedName",
                value: "User");

            migrationBuilder.UpdateData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2",
                column: "NormalizedName",
                value: "Deliverer");
        }
    }
}
