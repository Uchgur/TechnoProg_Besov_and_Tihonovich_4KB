using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionLogs_AspNetUsers_FeederUserId",
                table: "ActionLogs");

            migrationBuilder.AlterColumn<string>(
                name: "FeederUserId",
                table: "ActionLogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionLogs_AspNetUsers_FeederUserId",
                table: "ActionLogs",
                column: "FeederUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionLogs_AspNetUsers_FeederUserId",
                table: "ActionLogs");

            migrationBuilder.AlterColumn<string>(
                name: "FeederUserId",
                table: "ActionLogs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionLogs_AspNetUsers_FeederUserId",
                table: "ActionLogs",
                column: "FeederUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
