using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ticaret2.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 23, 5, 623, DateTimeKind.Local).AddTicks(6504), new Guid("179b33a3-c225-44a7-9b5f-e360e1a674f2") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 20, 23, 5, 623, DateTimeKind.Local).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 20, 23, 5, 623, DateTimeKind.Local).AddTicks(9302));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 10, 18, 23, 34, 536, DateTimeKind.Local).AddTicks(6454), new Guid("25a4c0e0-fcac-4c2e-b940-66fc982c68f6") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 18, 23, 34, 536, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 18, 23, 34, 537, DateTimeKind.Local).AddTicks(1));
        }
    }
}
