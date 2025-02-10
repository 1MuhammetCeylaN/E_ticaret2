using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ticaret2.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Orders",
                newName: "ProductNames");

            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 10, 14, 12, 19, 369, DateTimeKind.Local).AddTicks(1760), new Guid("1f5efd7c-b12d-414d-84a0-93f2d2192d4f") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 14, 12, 19, 369, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 14, 12, 19, 369, DateTimeKind.Local).AddTicks(5026));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductNames",
                table: "Orders",
                newName: "ProductName");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 10, 13, 14, 34, 324, DateTimeKind.Local).AddTicks(647), new Guid("0606da22-2daa-45dc-a459-e861215b4d2b") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 13, 14, 34, 324, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 10, 13, 14, 34, 324, DateTimeKind.Local).AddTicks(3416));
        }
    }
}
