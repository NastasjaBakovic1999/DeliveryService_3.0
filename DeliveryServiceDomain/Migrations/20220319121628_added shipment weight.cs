using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class addedshipmentweight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipmentWeight",
                table: "Shipments");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentWeightId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "ShipmentWeight",
                columns: new[] { "ShipmentWeightId", "Desc", "ShipmentWeightPrice" },
                values: new object[,]
                {
                    { 1, "Up to 0,5 kg", 250.0 },
                    { 2, "Over 0,5 to 2kg", 300.0 },
                    { 3, "Over 2 to 5kg", 390.0 },
                    { 4, "Over 5 to 10kg", 510.0 },
                    { 5, "Over 10 to 20kg", 700.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentWeightId",
                table: "Shipments",
                column: "ShipmentWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentWeight_ShipmentWeightId",
                table: "Shipments",
                column: "ShipmentWeightId",
                principalTable: "ShipmentWeight",
                principalColumn: "ShipmentWeightId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentWeight_ShipmentWeightId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "ShipmentWeight");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShipmentWeightId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShipmentWeightId",
                table: "Shipments");

            migrationBuilder.AddColumn<double>(
                name: "ShipmentWeight",
                table: "Shipments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
