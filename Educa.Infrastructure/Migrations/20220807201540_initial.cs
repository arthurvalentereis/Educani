using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educa.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_escolaridade",
                columns: table => new
                {
                    id_escolaridade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_escolaridade", x => x.id_escolaridade);
                });

            migrationBuilder.CreateTable(
                name: "tb_historico_escolar",
                columns: table => new
                {
                    id_historico_escolar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    formato = table.Column<string>(type: "varchar(50)", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    caminho_arquivo = table.Column<string>(type: "varchar(250)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_historico_escolar", x => x.id_historico_escolar);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    sobrenome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_escolaridade = table.Column<int>(type: "int", nullable: false),
                    id_historico_escolar = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_tb_usuarios_tb_escolaridade_id_escolaridade",
                        column: x => x.id_escolaridade,
                        principalTable: "tb_escolaridade",
                        principalColumn: "id_escolaridade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_usuarios_tb_historico_escolar_id_historico_escolar",
                        column: x => x.id_historico_escolar,
                        principalTable: "tb_historico_escolar",
                        principalColumn: "id_historico_escolar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_escolaridade",
                columns: new[] { "id_escolaridade", "atualizado_em", "criado_em", "descricao", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6943), new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6934), "Infantil", true },
                    { 2, new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6945), new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6945), "Fundamental", true },
                    { 3, new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6947), new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6946), "Médio", true },
                    { 4, new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6948), new DateTime(2022, 8, 7, 17, 15, 40, 519, DateTimeKind.Local).AddTicks(6947), "Superior", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuarios_id_escolaridade",
                table: "tb_usuarios",
                column: "id_escolaridade");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuarios_id_historico_escolar",
                table: "tb_usuarios",
                column: "id_historico_escolar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usuarios");

            migrationBuilder.DropTable(
                name: "tb_escolaridade");

            migrationBuilder.DropTable(
                name: "tb_historico_escolar");
        }
    }
}
