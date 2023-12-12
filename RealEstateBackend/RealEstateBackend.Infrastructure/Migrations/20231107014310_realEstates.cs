using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateBackend.Migrations
{
    /// <inheritdoc />
    public partial class realEstates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "realestates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ComercialType = table.Column<string>(type: "varchar(50)", nullable: false),
                    Title = table.Column<string>(type: "varchar(60)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Address = table.Column<string>(type: "varchar(150)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "varchar(70)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    SquareFoot = table.Column<double>(type: "double precision", nullable: false),
                    PrivateSquareFoot = table.Column<double>(type: "double precision", nullable: false),
                    SellValue = table.Column<double>(type: "double precision", nullable: false),
                    RentValue = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PropertyTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realestates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "realestates");
        }
    }
}
