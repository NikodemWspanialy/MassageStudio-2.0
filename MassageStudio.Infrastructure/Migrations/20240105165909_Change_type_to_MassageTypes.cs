using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_type_to_MassageTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_Types_TypeId",
                table: "Massages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "MassageTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MassageTypes",
                table: "MassageTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages",
                column: "TypeId",
                principalTable: "MassageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MassageTypes",
                table: "MassageTypes");

            migrationBuilder.RenameTable(
                name: "MassageTypes",
                newName: "Types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_Types_TypeId",
                table: "Massages",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
