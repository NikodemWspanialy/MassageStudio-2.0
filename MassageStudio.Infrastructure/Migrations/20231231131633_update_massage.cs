using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_massage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_AspNetUsers_MasseurId",
                table: "Massages");

            migrationBuilder.AlterColumn<string>(
                name: "MasseurName",
                table: "Massages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MasseurId",
                table: "Massages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_AspNetUsers_MasseurId",
                table: "Massages",
                column: "MasseurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_AspNetUsers_MasseurId",
                table: "Massages");

            migrationBuilder.AlterColumn<string>(
                name: "MasseurName",
                table: "Massages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasseurId",
                table: "Massages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_AspNetUsers_MasseurId",
                table: "Massages",
                column: "MasseurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
