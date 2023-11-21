using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nombremigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipopid",
                columns: table => new
                {
                    idTipoPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTipoPID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uct",
                columns: table => new
                {
                    idUCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    denominacion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    localidad = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    regional = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    tipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUCT);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "universidad",
                columns: table => new
                {
                    idUniversidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    direccion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUniversidad);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iniciativa_investigacion",
                columns: table => new
                {
                    idIniciativa_Investigacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_universidad = table.Column<int>(type: "int", nullable: true),
                    id_tipoPID = table.Column<int>(type: "int", nullable: true),
                    director = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    denominacion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    fecha_desde = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_hasta = table.Column<DateTime>(type: "datetime", nullable: true),
                    programa = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idIniciativa_Investigacion);
                    table.ForeignKey(
                        name: "id_tipoPID",
                        column: x => x.id_tipoPID,
                        principalTable: "tipopid",
                        principalColumn: "idTipoPID");
                    table.ForeignKey(
                        name: "id_universidad",
                        column: x => x.id_universidad,
                        principalTable: "universidad",
                        principalColumn: "idUniversidad");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pid",
                columns: table => new
                {
                    idPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    denominacion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    fecha_desde = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_hasta = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_universidad = table.Column<int>(type: "int", nullable: true),
                    id_tipoPID = table.Column<int>(type: "int", nullable: true),
                    director = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPID);
                    table.ForeignKey(
                        name: "id_tipoPID_FK_P",
                        column: x => x.id_tipoPID,
                        principalTable: "tipopid",
                        principalColumn: "idTipoPID");
                    table.ForeignKey(
                        name: "id_universidad_FK_P",
                        column: x => x.id_universidad,
                        principalTable: "universidad",
                        principalColumn: "idUniversidad");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uct_iniciativainvestigacion",
                columns: table => new
                {
                    idUCT_IniciativaInvestigacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_UCT = table.Column<int>(type: "int", nullable: true),
                    id_iniciativainvestigacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUCT_IniciativaInvestigacion);
                    table.ForeignKey(
                        name: "id_UCT_FK_UI",
                        column: x => x.id_UCT,
                        principalTable: "uct",
                        principalColumn: "idUCT");
                    table.ForeignKey(
                        name: "id_iniciativainvestigacion_FK_UI",
                        column: x => x.id_iniciativainvestigacion,
                        principalTable: "iniciativa_investigacion",
                        principalColumn: "idIniciativa_Investigacion");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pid_uct",
                columns: table => new
                {
                    idPID_UCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_PID = table.Column<int>(type: "int", nullable: true),
                    id_UCT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPID_UCT);
                    table.ForeignKey(
                        name: "id_PID_FK_U",
                        column: x => x.id_PID,
                        principalTable: "pid",
                        principalColumn: "idPID");
                    table.ForeignKey(
                        name: "id_UCT_FK_U",
                        column: x => x.id_UCT,
                        principalTable: "uct",
                        principalColumn: "idUCT");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "id_tipoPID_idx",
                table: "iniciativa_investigacion",
                column: "id_tipoPID");

            migrationBuilder.CreateIndex(
                name: "id_universidad_idx",
                table: "iniciativa_investigacion",
                column: "id_universidad");

            migrationBuilder.CreateIndex(
                name: "id_tipoPID_FK_P_idx",
                table: "pid",
                column: "id_tipoPID");

            migrationBuilder.CreateIndex(
                name: "id_universidad_FK_P_idx",
                table: "pid",
                column: "id_universidad");

            migrationBuilder.CreateIndex(
                name: "id_PID_FK_U_idx",
                table: "pid_uct",
                column: "id_PID");

            migrationBuilder.CreateIndex(
                name: "id_UCT_FK_U_idx",
                table: "pid_uct",
                column: "id_UCT");

            migrationBuilder.CreateIndex(
                name: "id_iniciativainvestigacion_FK_UI_idx",
                table: "uct_iniciativainvestigacion",
                column: "id_iniciativainvestigacion");

            migrationBuilder.CreateIndex(
                name: "id_UCT_FK_UI_idx",
                table: "uct_iniciativainvestigacion",
                column: "id_UCT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pid_uct");

            migrationBuilder.DropTable(
                name: "uct_iniciativainvestigacion");

            migrationBuilder.DropTable(
                name: "pid");

            migrationBuilder.DropTable(
                name: "uct");

            migrationBuilder.DropTable(
                name: "iniciativa_investigacion");

            migrationBuilder.DropTable(
                name: "tipopid");

            migrationBuilder.DropTable(
                name: "universidad");
        }
    }
}
