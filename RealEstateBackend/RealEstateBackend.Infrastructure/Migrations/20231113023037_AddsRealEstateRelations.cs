using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddsRealEstateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyTypeId",
                table: "realestates",
                newName: "RealEstateKindId");

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

            migrationBuilder.CreateIndex(
                name: "IX_realestates_RealEstateKindId",
                table: "realestates",
                column: "RealEstateKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_realestates_realestatekinds_RealEstateKindId",
                table: "realestates",
                column: "RealEstateKindId",
                principalTable: "realestatekinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_realestates_realestatekinds_RealEstateKindId",
                table: "realestates");

            migrationBuilder.DropIndex(
                name: "IX_realestates_RealEstateKindId",
                table: "realestates");

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

            migrationBuilder.RenameColumn(
                name: "RealEstateKindId",
                table: "realestates",
                newName: "PropertyTypeId");
        }
    }
}
