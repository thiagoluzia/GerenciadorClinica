using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GC.Infrastructure.Migrations
{
    public partial class RemovendoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAtendimento",
                table: "Medico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAtendimento",
                table: "Medico",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
