using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GC.Infrastructure.Migrations
{
    public partial class IncluindoEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdCalendarAgenda",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdEvento",
                table: "Atendimento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCalendarAgenda",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "Atendimento");
        }
    }
}
