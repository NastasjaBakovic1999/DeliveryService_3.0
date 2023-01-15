using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations.DeliveryService
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalService",
                columns: table => new
                {
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalServiceName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    AdditionalServicePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalService", x => x.AdditionalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentWeight",
                columns: table => new
                {
                    ShipmentWeightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    ShipmentWeightPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentWeight", x => x.ShipmentWeightId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentCode = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    ShipmentWeightId = table.Column<int>(type: "int", nullable: false),
                    ShipmentContent = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Sending_Id = table.Column<int>(type: "int", nullable: true),
                    Sending_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sending_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sending_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receiving_Id = table.Column<int>(type: "int", nullable: true),
                    Receiving_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receiving_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receiving_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ContactPersonPhone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipments_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_ShipmentWeight_ShipmentWeightId",
                        column: x => x.ShipmentWeightId,
                        principalTable: "ShipmentWeight",
                        principalColumn: "ShipmentWeightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalServiceShipments",
                columns: table => new
                {
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServiceShipments", x => new { x.AdditionalServiceId, x.ShipmentId });
                    table.ForeignKey(
                        name: "FK_AdditionalServiceShipments_AdditionalService_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalService",
                        principalColumn: "AdditionalServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalServiceShipments_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusShipments",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusShipments", x => new { x.StatusId, x.ShipmentId });
                    table.ForeignKey(
                        name: "FK_StatusShipments_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatusShipments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdditionalService",
                columns: new[] { "AdditionalServiceId", "AdditionalServiceName", "AdditionalServicePrice" },
                values: new object[,]
                {
                    { 1, "Signed delivery note", 50.0 },
                    { 2, "Return receipt", 50.0 },
                    { 3, "Additional packaging", 60.0 },
                    { 4, "Personal delivery", 60.0 },
                    { 5, "Value insurance", 80.0 },
                    { 6, "Email report", 30.0 },
                    { 7, "SMS report", 30.0 },
                    { 8, "Delivery today for tomorrow until 12h", 90.0 },
                    { 9, "Delivery today for tomorrow until 19h", 70.0 }
                });

            migrationBuilder.InsertData(
                table: "ShipmentWeight",
                columns: new[] { "ShipmentWeightId", "Desc", "ShipmentWeightPrice" },
                values: new object[,]
                {
                    { 5, "Over 10 to 20kg", 700.0 },
                    { 4, "Over 5 to 10kg", 510.0 },
                    { 3, "Over 2 to 5kg", 390.0 },
                    { 2, "Over 0,5 to 2kg", 300.0 },
                    { 1, "Up to 0,5 kg", 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "On the packaging" },
                    { 3, "Stored for shipping" },
                    { 4, "At the courier" },
                    { 5, "In transport" },
                    { 6, "Delivered" },
                    { 7, "Stored on hold" },
                    { 8, "Rejected" },
                    { 9, "Returned to sender" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceShipments_ShipmentId",
                table: "AdditionalServiceShipments",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentWeightId",
                table: "Shipments",
                column: "ShipmentWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusShipments_ShipmentId",
                table: "StatusShipments",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalServiceShipments");

            migrationBuilder.DropTable(
                name: "StatusShipments");

            migrationBuilder.DropTable(
                name: "AdditionalService");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Deliverer");

            migrationBuilder.DropTable(
                name: "ShipmentWeight");
        }
    }
}
