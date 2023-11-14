using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddsRelationToAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("05fa4826-98c9-46ab-9604-35afedb2f870"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("06d314b9-bfd6-432e-acff-7612b6d39239"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("279cecc6-b1d6-4a0d-85db-54433349531d"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("b4450201-4178-4d52-9700-ef6c8bedfa69"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("e2815177-8b18-467c-9e18-846ecf2392be"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("2e45f39b-d770-4106-bd61-b9d20cbe2b9f"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("a75a26e9-38ee-4224-a0f7-27c356e2edd1"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("c57037f9-a3b3-4985-86cf-bf1022e9847e"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("de7cd9fa-030a-4086-bad8-c7fc95478bf2"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("edf1b3d3-6299-4676-8a8b-90683d0fe9e7"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "realestates");

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "realestates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bedrooms",
                table: "realestates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Garage",
                table: "realestates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "realestatesamenities",
                columns: table => new
                {
                    AmenitiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RealEstatesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realestatesamenities", x => new { x.AmenitiesId, x.RealEstatesId });
                    table.ForeignKey(
                        name: "FK_realestatesamenities_amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_realestatesamenities_realestates_RealEstatesId",
                        column: x => x.RealEstatesId,
                        principalTable: "realestates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ac51cfd-b8b0-4dc9-ac4e-511f8cf8fba8"), "Piscina" },
                    { new Guid("41a63c90-8664-4b4c-aaa5-ac9ab957d5ca"), "Microondas" },
                    { new Guid("57be2fe0-0754-4a6e-a5c8-31a00355e901"), "Mobília" },
                    { new Guid("85b0e8bf-a464-41de-886b-bd244de84aac"), "Jardim" },
                    { new Guid("c85ddffa-756b-4723-8744-1444dc4a8bed"), "Churrasqueira" }
                });

            migrationBuilder.InsertData(
                table: "realestatekinds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("185f4186-02ef-4816-b5a8-30cc492e742b"), "Apartamento" },
                    { new Guid("1bda995f-4753-495e-a565-5e5bddc93535"), "Terreno" },
                    { new Guid("2f4bd07c-c916-426f-9e01-338ba2c38d4f"), "Sala Comercial" },
                    { new Guid("4818dfb3-a5c8-4805-8d0e-eea07676ad5b"), "Casa" },
                    { new Guid("b83b287a-329f-4b4e-8d1e-326e84cb030b"), "Área Rural" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_realestatesamenities_RealEstatesId",
                table: "realestatesamenities",
                column: "RealEstatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "realestatesamenities");

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("2ac51cfd-b8b0-4dc9-ac4e-511f8cf8fba8"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("41a63c90-8664-4b4c-aaa5-ac9ab957d5ca"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("57be2fe0-0754-4a6e-a5c8-31a00355e901"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("85b0e8bf-a464-41de-886b-bd244de84aac"));

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: new Guid("c85ddffa-756b-4723-8744-1444dc4a8bed"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("185f4186-02ef-4816-b5a8-30cc492e742b"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("1bda995f-4753-495e-a565-5e5bddc93535"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("2f4bd07c-c916-426f-9e01-338ba2c38d4f"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("4818dfb3-a5c8-4805-8d0e-eea07676ad5b"));

            migrationBuilder.DeleteData(
                table: "realestatekinds",
                keyColumn: "Id",
                keyValue: new Guid("b83b287a-329f-4b4e-8d1e-326e84cb030b"));

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "realestates");

            migrationBuilder.DropColumn(
                name: "Bedrooms",
                table: "realestates");

            migrationBuilder.DropColumn(
                name: "Garage",
                table: "realestates");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "realestates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05fa4826-98c9-46ab-9604-35afedb2f870"), "Jardim" },
                    { new Guid("06d314b9-bfd6-432e-acff-7612b6d39239"), "Piscina" },
                    { new Guid("279cecc6-b1d6-4a0d-85db-54433349531d"), "Mobília" },
                    { new Guid("b4450201-4178-4d52-9700-ef6c8bedfa69"), "Microondas" },
                    { new Guid("e2815177-8b18-467c-9e18-846ecf2392be"), "Churrasqueira" }
                });

            migrationBuilder.InsertData(
                table: "realestatekinds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2e45f39b-d770-4106-bd61-b9d20cbe2b9f"), "Área Rural" },
                    { new Guid("a75a26e9-38ee-4224-a0f7-27c356e2edd1"), "Terreno" },
                    { new Guid("c57037f9-a3b3-4985-86cf-bf1022e9847e"), "Casa" },
                    { new Guid("de7cd9fa-030a-4086-bad8-c7fc95478bf2"), "Sala Comercial" },
                    { new Guid("edf1b3d3-6299-4676-8a8b-90683d0fe9e7"), "Apartamento" }
                });
        }
    }
}
