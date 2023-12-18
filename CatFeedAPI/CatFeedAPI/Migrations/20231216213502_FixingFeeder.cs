using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixingFeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeders_AspNetUsers_FeederUserId",
                table: "Feeders");

            migrationBuilder.AlterColumn<string>(
                name: "FeederUserId",
                table: "Feeders",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeders_AspNetUsers_FeederUserId",
                table: "Feeders",
                column: "FeederUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeders_AspNetUsers_FeederUserId",
                table: "Feeders");

            migrationBuilder.AlterColumn<string>(
                name: "FeederUserId",
                table: "Feeders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeders_AspNetUsers_FeederUserId",
                table: "Feeders",
                column: "FeederUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
