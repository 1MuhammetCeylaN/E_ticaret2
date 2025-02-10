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
                values: new object[] { new DateTime(2025, 2, 10, 20, 37, 10, 817, DateTimeKind.Local).AddTicks(5220), new Guid("05a7e38d-029e-4bb1-a55e-e517e3ef5a49") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 20, 37, 10, 817, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 20, 37, 10, 817, DateTimeKind.Local).AddTicks(7978));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 10, 20, 30, 51, 524, DateTimeKind.Local).AddTicks(6986), new Guid("471e37a3-841f-47d1-8a9d-5df1ec16e421") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 20, 30, 51, 524, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 20, 30, 51, 524, DateTimeKind.Local).AddTicks(9805));
        }
    }
}
