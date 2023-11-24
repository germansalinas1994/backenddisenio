using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "universidad",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "universidad",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "regional",
                table: "uct",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "localidad",
                table: "uct",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "denominacion",
                table: "uct",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "uct",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "tipopid",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "tipopid",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "director",
                table: "pid",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "denominacion",
                table: "pid",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "programa",
                table: "iniciativa_investigacion",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "director",
                table: "iniciativa_investigacion",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "denominacion",
                table: "iniciativa_investigacion",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "tipopid",
                columns: new[] { "idTipoPID", "codigo", "descripcion" },
                values: new object[,]
                {
                    { 1, "PIDTC", "PID para Equipos de Trabajo Consolidado" },
                    { 2, "PIDEC", "PID para Equipos de Trabajo en Consolidación" },
                    { 3, "PIDPP", "PID de Iniciación a la Investigación o Primer Proyecto" },
                    { 4, "PIDA", "PID Asociativo" }
                });

            migrationBuilder.InsertData(
                table: "uct",
                columns: new[] { "idUCT", "codigo", "denominacion", "localidad", "regional", "tipo" },
                values: new object[,]
                {
                    { 1, "CIDER", "Centro de Investigación y Desarrollo Regional", "San Rafael", "San Rafael", 1 },
                    { 2, "CODAPLI", "Centro de Investigación de Codiseño Aplicado", "La Plata", "La Plata", 1 },
                    { 3, "IEC", "Grupo de Investigación en Enseñanza de las Ciencias", "La Plata", "La Plata", 2 },
                    { 4, "GIDAS", "Grupo de Investigación y Desarrollo Aplicado a Sistemas", "La Plata", "La Plata", 2 }
                });

            migrationBuilder.InsertData(
                table: "universidad",
                columns: new[] { "idUniversidad", "direccion", "nombre" },
                values: new object[,]
                {
                    { 1, "Calle 60 esq 124", "UTN FRLP" },
                    { 2, "Calle 1 esq 47", "UNLP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tipopid",
                keyColumn: "idTipoPID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tipopid",
                keyColumn: "idTipoPID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tipopid",
                keyColumn: "idTipoPID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tipopid",
                keyColumn: "idTipoPID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "uct",
                keyColumn: "idUCT",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "uct",
                keyColumn: "idUCT",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "uct",
                keyColumn: "idUCT",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "uct",
                keyColumn: "idUCT",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "universidad",
                keyColumn: "idUniversidad",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "universidad",
                keyColumn: "idUniversidad",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "universidad",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "universidad",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "regional",
                table: "uct",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "localidad",
                table: "uct",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "denominacion",
                table: "uct",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "uct",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "tipopid",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "tipopid",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "director",
                table: "pid",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "denominacion",
                table: "pid",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "programa",
                table: "iniciativa_investigacion",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "director",
                table: "iniciativa_investigacion",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "denominacion",
                table: "iniciativa_investigacion",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
