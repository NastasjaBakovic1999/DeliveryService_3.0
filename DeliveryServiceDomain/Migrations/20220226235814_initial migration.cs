using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class initialmigration : Migration
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
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
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
                name: "Deliverers",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverers", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Deliverers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([int],session_context(N'PersonId')))"),
                    DelivererId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([int],session_context(N'PersonId')))"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipments_Deliverers_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Deliverers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Shipments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PersonId",
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
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Pera", "Peric", "per1c4", "perica" },
                    { 2, "Zika", "Zikic", "z1k1c4", "zikica" },
                    { 3, "Nastasja", "Bakovic", "N4st4sj4", "nastasja" },
                    { 4, "Stefan", "Antic", "ant33", "stefan" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "ShipmentTypeId", "ShipmentTypeName", "ShipmentTypePrice" },
                values: new object[,]
                {
                    { 1, "Standardna", 220.0 },
                    { 3, "Međunarodna", 900.0 },
                    { 2, "Specijalna", 350.0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Zakazana" },
                    { 2, "Na pakovanju" },
                    { 3, "Uskladištena za slanje" },
                    { 4, "Kod kurira" },
                    { 5, "U transportu" },
                    { 6, "Uručena" },
                    { 7, "Uskladištena na čekanju" },
                    { 8, "Odbijena" },
                    { 9, "Vraćena pošiljaocu" }
                });

            migrationBuilder.InsertData(
                table: "Deliverers",
                column: "PersonId",
                values: new object[]
                {
                    3,
                    4
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "PersonId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "065/111-222-33" },
                    { 2, "064/444-555-66" }
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
                name: "Deliverers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ShipmentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
