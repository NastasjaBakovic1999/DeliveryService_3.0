using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class deletedshipmenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentTypes_ShipmentTypeId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "ShipmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShipmentTypeId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShipmentTypeId",
                table: "Shipments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentTypeId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "ShipmentTypeId", "ShipmentTypeName", "ShipmentTypePrice" },
                values: new object[] { 1, "Standard", 220.0 });

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "ShipmentTypeId", "ShipmentTypeName", "ShipmentTypePrice" },
                values: new object[] { 2, "Special", 350.0 });

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "ShipmentTypeId", "ShipmentTypeName", "ShipmentTypePrice" },
                values: new object[] { 3, "International", 900.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentTypeId",
                table: "Shipments",
                column: "ShipmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentTypes_ShipmentTypeId",
                table: "Shipments",
                column: "ShipmentTypeId",
                principalTable: "ShipmentTypes",
                principalColumn: "ShipmentTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
