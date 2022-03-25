using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceDomain.Migrations
{
    public partial class idkwhatchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Customer_UserId",
                table: "Shipments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shipments",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_UserId",
                table: "Shipments",
                newName: "IX_Shipments_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Customer_CustomerId",
                table: "Shipments",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Customer_CustomerId",
                table: "Shipments");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Shipments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                newName: "IX_Shipments_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "DelivererId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValueSql: "(CONVERT([int],session_context(N'PersonId')))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValueSql: "(CONVERT([int],session_context(N'PersonId')))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Customer_UserId",
                table: "Shipments",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
