using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devsu.Migrations
{
    /// <inheritdoc />
    public partial class AjustesHerencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasena",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Personas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Personas",
                type: "bit",
                nullable: true);
        }
    }
}
