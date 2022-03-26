using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class changedpasswordhasherversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e38ee56-8a11-43e2-a48e-e6b4510900c5", "AQAAAAEAACcQAAAAECSg5L5RMqpSy48KkdAWu9lz7KYfeUjAj83Ov60k6r3h/2GHRA+UtUlkBTnj3GZWsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3853602-c837-4a0e-95c4-30be7b3e27f4", "AQAAAAEAACcQAAAAEPs0v8LOOj+ZbgjrZtDwf1CblCzj8jeG3wWegU1edHhUpFUutYooOf/jhMun2dPvHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20706632-a1e9-4164-92dc-757914c36ec3", "AQAAAAEAACcQAAAAEEeRnYAitIOLiptD2aAAT/OFEPPQaiqarC3yC5pnKOwHLbLTX45e6OZxKe3Q2VnDzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b89d8b62-bebc-478e-a6b2-b2851d295620", "AQAAAAEAACcQAAAAEAG07WhKSm8llAbqawaSfe9txdtsWgjLdBkXS36CBJHfNqJQV47Kx3LNG4m/xGLBVA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "350a99bb-a6bf-4773-b914-f01e9c0febcc", "AENeyPSGFin5nIQVypK0OiJ5VfiAPl2WH2lN5wtT3Lex5I7FmF9tAycyFQbumwjRPQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82f88737-a23b-4f6b-a8f7-b6ab02a260ad", "ANUT70ebeElcUyaQRppJ5nf9hfhm0C8yF984+v+4/owin+fhkb1H34c1AIWUqRStgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a1849e1-5928-4bd5-bc4d-eb3d8a4b0cdc", "AOsVDRWbq19lhhtoaljZiJ7oagRTkhlaSg2RabhH51EvDO8W+fw+jbAeakzvCGljyw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e4fe5b4-f086-487f-9bfd-25c3058c54cf", "APYDaf/x7sQLlT17BN3Ncb+WVqTT2Rhm7uYyZjZUhxmslfg4Ib49YAWFrmqIK48JWg==" });
        }
    }
}
