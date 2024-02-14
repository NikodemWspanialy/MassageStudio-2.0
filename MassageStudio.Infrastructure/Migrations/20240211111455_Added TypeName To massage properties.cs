using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTypeNameTomassageproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Massages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Massages");
        }
    }
}
