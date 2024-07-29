using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XUMHUB.Migrations
{
    /// <inheritdoc />
    public partial class AddLaptopModelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "LaptopModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopModels", x => x.Id);
                });

           
        }
    }
}
