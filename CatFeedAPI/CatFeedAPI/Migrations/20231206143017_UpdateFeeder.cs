using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeedrsUsers_FeederId",
                table: "FeedrsUsers");

            migrationBuilder.CreateIndex(
                name: "IX_FeedrsUsers_FeederId",
                table: "FeedrsUsers",
                column: "FeederId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeedrsUsers_FeederId",
                table: "FeedrsUsers");

            migrationBuilder.CreateIndex(
                name: "IX_FeedrsUsers_FeederId",
                table: "FeedrsUsers",
                column: "FeederId");
        }
    }
}
