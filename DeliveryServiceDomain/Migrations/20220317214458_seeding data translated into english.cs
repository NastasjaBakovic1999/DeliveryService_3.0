using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class seedingdatatranslatedintoenglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 1,
                column: "AdditionalServiceName",
                value: "Signed delivery note");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 2,
                column: "AdditionalServiceName",
                value: "Return receipt");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 3,
                column: "AdditionalServiceName",
                value: "Additional packaging");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 4,
                column: "AdditionalServiceName",
                value: "Personal delivery");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 5,
                column: "AdditionalServiceName",
                value: "Value insurance");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 6,
                column: "AdditionalServiceName",
                value: "Email report");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 7,
                column: "AdditionalServiceName",
                value: "SMS report");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 8,
                column: "AdditionalServiceName",
                value: "Delivery today for tomorrow until 12h");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 9,
                column: "AdditionalServiceName",
                value: "Delivery today for tomorrow until 19h");

            migrationBuilder.UpdateData(
                table: "ShipmentTypes",
                keyColumn: "ShipmentTypeId",
                keyValue: 1,
                column: "ShipmentTypeName",
                value: "Standard");

            migrationBuilder.UpdateData(
                table: "ShipmentTypes",
                keyColumn: "ShipmentTypeId",
                keyValue: 2,
                column: "ShipmentTypeName",
                value: "Special");

            migrationBuilder.UpdateData(
                table: "ShipmentTypes",
                keyColumn: "ShipmentTypeId",
                keyValue: 3,
                column: "ShipmentTypeName",
                value: "International");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "StatusName",
                value: "Scheduled");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "StatusName",
                value: "On the packaging");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "StatusName",
                value: "Stored for shipping");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "StatusName",
                value: "At the courier");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "StatusName",
                value: "In transport");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "StatusName",
                value: "Delivered");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "StatusName",
                value: "Stored on hold");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 8,
                column: "StatusName",
                value: "Rejected");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 9,
                column: "StatusName",
                value: "Returned to sender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 1,
                column: "AdditionalServiceName",
                value: "Potpisana otpremnica");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 2,
                column: "AdditionalServiceName",
                value: "Povratnica");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 3,
                column: "AdditionalServiceName",
                value: "Dodatna ambalaza");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 4,
                column: "AdditionalServiceName",
                value: "Lično uručenje");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 5,
                column: "AdditionalServiceName",
                value: "Osiguranje vrednosti");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 6,
                column: "AdditionalServiceName",
                value: "Email izveštaj");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 7,
                column: "AdditionalServiceName",
                value: "SMS izveštaj");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 8,
                column: "AdditionalServiceName",
                value: "Uručenje danas za sutra do 12h");

            migrationBuilder.UpdateData(
                table: "AdditionalService",
                keyColumn: "AdditionalServiceId",
                keyValue: 9,
                column: "AdditionalServiceName",
                value: "Uručenje danas za sutra do 19h");

            migrationBuilder.UpdateData(
                table: "ShipmentTypes",
                keyColumn: "ShipmentTypeId",
                keyValue: 1,
                column: "ShipmentTypeName",
                value: "Standardna");

            migrationBuilder.UpdateData(
                table: "ShipmentTypes",
                keyColumn: "ShipmentTypeId",
                keyValue: 2,
                column: "ShipmentTypeName",
                value: "Specijalna");

            migrationBuilder.UpdateData(
                table: "ShipmentTypes",
                keyColumn: "ShipmentTypeId",
                keyValue: 3,
                column: "ShipmentTypeName",
                value: "Međunarodna");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "StatusName",
                value: "Zakazana");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "StatusName",
                value: "Na pakovanju");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "StatusName",
                value: "Uskladištena za slanje");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "StatusName",
                value: "Kod kurira");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "StatusName",
                value: "U transportu");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "StatusName",
                value: "Uručena");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "StatusName",
                value: "Uskladištena na čekanju");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 8,
                column: "StatusName",
                value: "Odbijena");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 9,
                column: "StatusName",
                value: "Vraćena pošiljaocu");
        }
    }
}
