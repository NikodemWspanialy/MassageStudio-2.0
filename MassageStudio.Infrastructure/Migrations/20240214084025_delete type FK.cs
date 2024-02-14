using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletetypeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages");

            migrationBuilder.DropIndex(
                name: "IX_Massages_TypeId",
                table: "Massages");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Massages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Massages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Massages_TypeId",
                table: "Massages",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages",
                column: "TypeId",
                principalTable: "MassageTypes",
                principalColumn: "Id");
        }
    }
}
