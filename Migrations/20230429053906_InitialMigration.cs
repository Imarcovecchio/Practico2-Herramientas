using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico_2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaDeAlta = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaDeAlta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Estatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "Estatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    EstatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesores_Estatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "Estatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaDeAlta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfesorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_Estatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "Estatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curso_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursosEstudiantes",
                columns: table => new
                {
                    EstudiantesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosEstudiantes", x => new { x.CursoId, x.EstudiantesId });
                    table.ForeignKey(
                        name: "FK_CursosEstudiantes_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosEstudiantes_Estudiantes_EstudiantesId",
                        column: x => x.EstudiantesId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_EstatusId",
                table: "Curso",
                column: "EstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_ProfesorId",
                table: "Curso",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_CursosEstudiantes_EstudiantesId",
                table: "CursosEstudiantes",
                column: "EstudiantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_EstatusId",
                table: "Estudiantes",
                column: "EstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_EstatusId",
                table: "Profesores",
                column: "EstatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursosEstudiantes");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
