using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixingFeederAndAddingFeederUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FeedrsUsers",
                columns: table => new
                {
                    FeederId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedrsUsers", x => new { x.UserId, x.FeederId });
                    table.ForeignKey(
                        name: "FK_FeedrsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedrsUsers_Feeders_FeederId",
                        column: x => x.FeederId,
                        principalTable: "Feeders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedrsUsers_FeederId",
                table: "FeedrsUsers",
                column: "FeederId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedrsUsers");

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
    }
}
