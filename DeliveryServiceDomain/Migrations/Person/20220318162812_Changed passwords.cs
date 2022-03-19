using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations.Person
{
    public partial class Changedpasswords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
