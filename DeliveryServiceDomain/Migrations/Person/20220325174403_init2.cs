using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations.Person
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa5791d0-de16-46bf-9496-77d3c6a717cc", "AQAAAAEAACcQAAAAEEMjSi3UOzWEytP4+GofKv/v6tjHDay4ytbuehi44UDQjcTFh9e4SLslExr5xb6c7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd111ca0-e67e-4de8-a0b3-dd4c60c4e6b8", "AQAAAAEAACcQAAAAEDGnOZLKqHsjhpWMraWLZbfofE4PdHUFNQawrO4dEI+O4o0J2xmYVxHFa8gRrnhgDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb8adfe1-6844-474f-b7e0-e8f0abd4e2a0", "AQAAAAEAACcQAAAAEF97RO35n7hdeCmdLZxxSaRL3giZa8mDIGy5hnHQXnf5dnAKyORluVPdWscgWieqfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed149c7e-4c3e-42d1-b8a7-638d83188630", "AQAAAAEAACcQAAAAEGW4ITJDTKkpC45/UBUSSSJ5FaIC04BHGveSNLnfnV/mw6AS/GdND87yvZhTyH6E8w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65552e09-2103-4284-a036-e2f3d954325f", "AQAAAAEAACcQAAAAEINfhc6QvZIMxRjsR3Y6jYFCRNsCBN/c1edwr2BUOia4hJ0Jh8RUyREi0dkHWikQYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "314e1e13-b22f-4a47-bcca-16a7a35f7606", "AQAAAAEAACcQAAAAEIDbrqLORZFY9pJx2S/0m3veQ30sazqc5PfvG73eDuOayCpFDV+FLDv23HlZsx2Jqg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b29ea42c-a784-4e56-9200-77acbcea3a89", "AQAAAAEAACcQAAAAEEvHiv9BDqd2Ul8bwmvF8CjW0ndOb2XG5H1SJ84b7VZmKVrKfhsoW9eb/5XZRCpr7w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09ab1f2b-e9bf-4f27-ab68-5b0e8844ac58", "AQAAAAEAACcQAAAAEGXZdrUFDkP19WdXHUNg1JCqR0EWyg4TTkeZt48pMKa9joC5Fq7aIyLJHORClvhaIQ==" });
        }
    }
}
