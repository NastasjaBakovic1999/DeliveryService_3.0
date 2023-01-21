using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryServiceDomain.Migrations.DeliveryService
{
    public partial class GetStatusTimelineByShipmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE GetStatusesTimeline
	                            @ShipmentId INT
                                AS
                                BEGIN
	                                SET NOCOUNT ON;
	                                SELECT StatusName, StatusTime
	                                FROM StatusShipments ss
	                                INNER JOIN Statuses s ON s.StatusId = ss.StatusId
	                                WHERE ss.ShipmentId = @ShipmentId
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE GetStatusesTimeline";
            migrationBuilder.Sql(procedure);
        }
    }
}
