using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations.Person
{
    public partial class changedpasswordhasher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c86af163-76ba-4857-93d6-03424b00d7f2", "AQAAAAEAACcQAAAAEHqQVw/3J1fcf4EfalplegPFkaaIy/ZYJOtMOno/Q/Ue19bj/hk+PblXMiSWvpVbeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c69a266-ac4a-4fb8-9d26-841e6af7d149", "AQAAAAEAACcQAAAAECoaxQfyYv+uNXTo1/jfCz47BrsbvvN71D8K77h4Bo3wyj4qhDxPv4RHcvxSm8TQ+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8e7d5a4-2852-43d0-8c87-36e9a8845c62", "AQAAAAEAACcQAAAAEDVb/nGQcrZ9VF0nwfkyoVzCz5tvmE2/DB59OGP2fSvLN92+pp1OOyyrqnVQgbQY7w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bcda1dec-9d4f-4434-a32c-c199aa0e0de5", "AQAAAAEAACcQAAAAEBTXMUR/18lVaPo3Ou+tRTtPgVQsPe6k2lHnQPOpFqFSutxLnXiYblp+H9QhJU7kOQ==" });
        }
    }
}
