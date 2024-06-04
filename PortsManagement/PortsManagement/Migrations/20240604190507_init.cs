using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortsManagement.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    PortCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.PortCode);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminals_Ports_PortCode",
                        column: x => x.PortCode,
                        principalTable: "Ports",
                        principalColumn: "PortCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ports",
                columns: new[] { "PortCode", "AddedDate", "LastEditedDate", "Name" },
                values: new object[,]
                {
                    { "PORT1", new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9752), new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9756), "Port One" },
                    { "PORT2", new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9757), new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9758), "Port Two" }
                });

            migrationBuilder.InsertData(
                table: "Terminals",
                columns: new[] { "Id", "AddedDate", "IsActive", "LastEditedDate", "Latitude", "Longitude", "Name", "PortCode" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9859), true, new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9860), 10.0, 20.0, "Terminal 1A", "PORT1" },
                    { 2, new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9862), true, new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9862), 30.0, 40.0, "Terminal 2A", "PORT2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ports_PortCode",
                table: "Ports",
                column: "PortCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_Name_PortCode",
                table: "Terminals",
                columns: new[] { "Name", "PortCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_PortCode",
                table: "Terminals",
                column: "PortCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Ports");
        }
    }
}
