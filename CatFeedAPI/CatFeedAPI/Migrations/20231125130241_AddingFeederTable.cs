using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingFeederTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedWeight = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedQuantity = table.Column<int>(type: "int", nullable: true),
                    WorkingHours = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedPresence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeders");
        }
    }
}
