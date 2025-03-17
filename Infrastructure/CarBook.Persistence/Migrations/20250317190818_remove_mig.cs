using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class remove_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentACarProcesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentACarProcesses",
                columns: table => new
                {
                    RentACarProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DropOffDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DropOffDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffLocationID = table.Column<int>(type: "int", nullable: false),
                    DropOffTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PickUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpLocationID = table.Column<int>(type: "int", nullable: false),
                    PickUpTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentACarProcesses", x => x.RentACarProcessID);
                    table.ForeignKey(
                        name: "FK_RentACarProcesses_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentACarProcesses_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentACarProcesses_CarID",
                table: "RentACarProcesses",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_RentACarProcesses_CustomerID",
                table: "RentACarProcesses",
                column: "CustomerID");
        }
    }
}
