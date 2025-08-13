using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolasDeIdiomasApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUMERO = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    ANO = table.Column<int>(type: "int", nullable: false),
                    NIVEL_TURMA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ALUNO_TURMA",
                columns: table => new
                {
                    ALUNO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TURMA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO_TURMA", x => new { x.ALUNO_ID, x.TURMA_ID });
                    table.ForeignKey(
                        name: "FK_ALUNO_TURMA_ALUNO_ALUNO_ID",
                        column: x => x.ALUNO_ID,
                        principalTable: "ALUNO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALUNO_TURMA_TURMA_TURMA_ID",
                        column: x => x.TURMA_ID,
                        principalTable: "TURMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_CPF",
                table: "ALUNO",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_TURMA_TURMA_ID",
                table: "ALUNO_TURMA",
                column: "TURMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TURMA_NUMERO",
                table: "TURMA",
                column: "NUMERO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNO_TURMA");

            migrationBuilder.DropTable(
                name: "ALUNO");

            migrationBuilder.DropTable(
                name: "TURMA");
        }
    }
}
