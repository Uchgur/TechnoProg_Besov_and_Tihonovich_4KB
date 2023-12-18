using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixixngDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedrsUsers");

            migrationBuilder.AddColumn<string>(
                name: "FeederUserId",
                table: "Feeders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeederUserId",
                table: "ActionLogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feeders_FeederUserId",
                table: "Feeders",
                column: "FeederUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionLogs_FeederUserId",
                table: "ActionLogs",
                column: "FeederUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionLogs_AspNetUsers_FeederUserId",
                table: "ActionLogs",
                column: "FeederUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeders_AspNetUsers_FeederUserId",
                table: "Feeders",
                column: "FeederUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionLogs_AspNetUsers_FeederUserId",
                table: "ActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeders_AspNetUsers_FeederUserId",
                table: "Feeders");

            migrationBuilder.DropIndex(
                name: "IX_Feeders_FeederUserId",
                table: "Feeders");

            migrationBuilder.DropIndex(
                name: "IX_ActionLogs_FeederUserId",
                table: "ActionLogs");

            migrationBuilder.DropColumn(
                name: "FeederUserId",
                table: "Feeders");

            migrationBuilder.DropColumn(
                name: "FeederUserId",
                table: "ActionLogs");

            migrationBuilder.CreateTable(
                name: "FeedrsUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeederId = table.Column<int>(type: "int", nullable: false)
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
                column: "FeederId",
                unique: true);
        }
    }
}
