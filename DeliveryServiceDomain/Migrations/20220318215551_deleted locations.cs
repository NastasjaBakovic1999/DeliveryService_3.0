using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class deletedlocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Locations_ReceivingLocationId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Locations_SendingLocationId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ReceivingLocationId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_SendingLocationId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "PostalNo",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ReceivingLocationId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "SendingLocationId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Shipments");

            migrationBuilder.AddColumn<string>(
                name: "ReceivingAddress",
                table: "Shipments",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceivingCity",
                table: "Shipments",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceivingPostalCode",
                table: "Shipments",
                type: "varchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendingAddress",
                table: "Shipments",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendingCity",
                table: "Shipments",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendingPostalCode",
                table: "Shipments",
                type: "varchar(5)",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivingAddress",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ReceivingCity",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ReceivingPostalCode",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "SendingAddress",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "SendingCity",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "SendingPostalCode",
                table: "Shipments");

            migrationBuilder.AddColumn<string>(
                name: "PostalNo",
                table: "Shipments",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReceivingLocationId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SendingLocationId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Shipments",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { 1, "Beograd" },
                    { 23, "Čačak" },
                    { 22, "Užice" },
                    { 21, "Subotica" },
                    { 20, "Sremska Mitrovica" },
                    { 19, "Sombor" },
                    { 18, "Smederevo" },
                    { 17, "Priština" },
                    { 16, "Požarevac" },
                    { 15, "Pančevo" },
                    { 14, "Novi Sad" },
                    { 24, "Šabac" },
                    { 13, "Novi Pazar" },
                    { 11, "Loznica" },
                    { 10, "Leskovac" },
                    { 9, "Kruševac" },
                    { 8, "Kraljevo" },
                    { 7, "Kragujevac" },
                    { 6, "Jagodina" },
                    { 5, "Zrenjanin" },
                    { 4, "Zaječar" },
                    { 3, "Vranje" },
                    { 2, "Valjevo" },
                    { 12, "Niš" },
                    { 25, "Pirot" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ReceivingLocationId",
                table: "Shipments",
                column: "ReceivingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_SendingLocationId",
                table: "Shipments",
                column: "SendingLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Locations_ReceivingLocationId",
                table: "Shipments",
                column: "ReceivingLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Locations_SendingLocationId",
                table: "Shipments",
                column: "SendingLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
