using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
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
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentTypes",
                columns: table => new
                {
                    ShipmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentTypeName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ShipmentTypePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTypes", x => x.ShipmentTypeId);
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
                    ShipmentWeight = table.Column<double>(type: "float", nullable: false),
                    ShipmentContent = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ShipmentTypeId = table.Column<int>(type: "int", nullable: false),
                    SendingLocationId = table.Column<int>(type: "int", nullable: false),
                    ReceivingLocationId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    PostalNo = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    ContactPersonName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ContactPersonPhone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([int],session_context(N'PersonId')))"),
                    DelivererId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([int],session_context(N'PersonId')))"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipments_Customer_UserId",
                        column: x => x.UserId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_Deliverer_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Deliverer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_Locations_ReceivingLocationId",
                        column: x => x.ReceivingLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Locations_SendingLocationId",
                        column: x => x.SendingLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_ShipmentTypes_ShipmentTypeId",
                        column: x => x.ShipmentTypeId,
                        principalTable: "ShipmentTypes",
                        principalColumn: "ShipmentTypeId",
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
                    { 1, "Potpisana otpremnica", 50.0 },
                    { 2, "Povratnica", 50.0 },
                    { 3, "Dodatna ambalaza", 60.0 },
                    { 4, "Lično uručenje", 60.0 },
                    { 5, "Osiguranje vrednosti", 80.0 },
                    { 6, "Email izveštaj", 30.0 },
                    { 7, "SMS izveštaj", 30.0 },
                    { 8, "Uručenje danas za sutra do 12h", 90.0 },
                    { 9, "Uručenje danas za sutra do 19h", 70.0 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { 16, "Požarevac" },
                    { 17, "Priština" },
                    { 18, "Smederevo" },
                    { 19, "Sombor" },
                    { 20, "Sremska Mitrovica" },
                    { 24, "Šabac" },
                    { 22, "Užice" },
                    { 23, "Čačak" },
                    { 15, "Pančevo" },
                    { 25, "Pirot" },
                    { 21, "Subotica" },
                    { 13, "Novi Pazar" },
                    { 14, "Novi Sad" },
                    { 1, "Beograd" },
                    { 12, "Niš" },
                    { 2, "Valjevo" },
                    { 3, "Vranje" },
                    { 5, "Zrenjanin" },
                    { 6, "Jagodina" },
                    { 4, "Zaječar" },
                    { 8, "Kraljevo" },
                    { 9, "Kruševac" },
                    { 10, "Leskovac" },
                    { 11, "Loznica" },
                    { 7, "Kragujevac" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "ShipmentTypeId", "ShipmentTypeName", "ShipmentTypePrice" },
                values: new object[,]
                {
                    { 1, "Standardna", 220.0 },
                    { 2, "Specijalna", 350.0 },
                    { 3, "Međunarodna", 900.0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 6, "Uručena" },
                    { 7, "Uskladištena na čekanju" },
                    { 5, "U transportu" },
                    { 8, "Odbijena" },
                    { 3, "Uskladištena za slanje" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 2, "Na pakovanju" },
                    { 1, "Zakazana" },
                    { 4, "Kod kurira" },
                    { 9, "Vraćena pošiljaocu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceShipments_ShipmentId",
                table: "AdditionalServiceShipments",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_DelivererId",
                table: "Shipments",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ReceivingLocationId",
                table: "Shipments",
                column: "ReceivingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_SendingLocationId",
                table: "Shipments",
                column: "SendingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentTypeId",
                table: "Shipments",
                column: "ShipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_UserId",
                table: "Shipments",
                column: "UserId");

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
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ShipmentTypes");
        }
    }
}
