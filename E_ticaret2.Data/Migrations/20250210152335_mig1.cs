using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ticaret2.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 10, 14, 17, 1, 287, DateTimeKind.Local).AddTicks(7221), new Guid("0f4c3375-fd7d-469e-bff7-1966fd69f780") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 14, 17, 1, 288, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 14, 17, 1, 288, DateTimeKind.Local).AddTicks(290));
        }
    }
}
