using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GC.Infrastructure.Persistence.Migrations
{
    public partial class AjuetsesEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Pacientes",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Medico",
                newName: "UF");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAtendimento",
                table: "Medico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoAtendimento = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Medico_Id",
                        column: x => x.Id,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimento_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimento_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atendimento_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdPaciente",
                table: "Atendimento",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdServico",
                table: "Atendimento",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteId",
                table: "Atendimento",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "IdAtendimento",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Medico");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Pacientes",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Medico",
                newName: "Endereco");
        }
    }
}
