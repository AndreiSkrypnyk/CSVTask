using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETLProject.Migrations
{
    public partial class changeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PassengerCount",
                table: "Trips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PULocationID",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DOLocationID",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DOLocationID",
                table: "Trips",
                column: "DOLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DropoffDateTime",
                table: "Trips",
                column: "DropoffDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_PickupDateTime",
                table: "Trips",
                column: "PickupDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_PULocationID",
                table: "Trips",
                column: "PULocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TripDistance",
                table: "Trips",
                column: "TripDistance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trips_DOLocationID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DropoffDateTime",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_PickupDateTime",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_PULocationID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_TripDistance",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerCount",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PULocationID",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DOLocationID",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
