using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fechas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "uct_iniciativainvestigacion",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "uct_iniciativainvestigacion",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "uct_iniciativainvestigacion",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "pid_uct",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "pid_uct",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "pid_uct",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "pid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "pid",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "iniciativa_investigacion",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "iniciativa_investigacion",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "iniciativa_investigacion",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "uct_iniciativainvestigacion");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "uct_iniciativainvestigacion");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "uct_iniciativainvestigacion");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "pid_uct");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "pid_uct");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "pid_uct");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "pid");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "pid");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "iniciativa_investigacion");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "iniciativa_investigacion");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "iniciativa_investigacion");
        }
    }
}
