using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToFeederTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkingHours",
                table: "Feeders",
                newName: "WorkingTime");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Feeders",
                newName: "ReactionTime");

            migrationBuilder.RenameColumn(
                name: "FeedWeight",
                table: "Feeders",
                newName: "FooddWeight");

            migrationBuilder.RenameColumn(
                name: "FeedQuantity",
                table: "Feeders",
                newName: "FoodAtATime");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Feeders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Feeders_UserId",
                table: "Feeders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeders_AspNetUsers_UserId",
                table: "Feeders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeders_AspNetUsers_UserId",
                table: "Feeders");

            migrationBuilder.DropIndex(
                name: "IX_Feeders_UserId",
                table: "Feeders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Feeders");

            migrationBuilder.RenameColumn(
                name: "WorkingTime",
                table: "Feeders",
                newName: "WorkingHours");

            migrationBuilder.RenameColumn(
                name: "ReactionTime",
                table: "Feeders",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "FooddWeight",
                table: "Feeders",
                newName: "FeedWeight");

            migrationBuilder.RenameColumn(
                name: "FoodAtATime",
                table: "Feeders",
                newName: "FeedQuantity");
        }
    }
}
