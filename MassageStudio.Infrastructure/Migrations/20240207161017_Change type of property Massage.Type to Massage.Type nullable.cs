using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangetypeofpropertyMassageTypetoMassageTypenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Massages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages",
                column: "TypeId",
                principalTable: "MassageTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Massages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_MassageTypes_TypeId",
                table: "Massages",
                column: "TypeId",
                principalTable: "MassageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
