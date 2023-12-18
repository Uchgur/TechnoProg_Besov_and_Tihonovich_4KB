using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFeedAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingFieldsToFeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReactionTime",
                table: "Feeders",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Feeders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Interval",
                table: "Feeders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimesCatShouldEat",
                table: "Feeders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Feeders");

            migrationBuilder.DropColumn(
                name: "Interval",
                table: "Feeders");

            migrationBuilder.DropColumn(
                name: "TimesCatShouldEat",
                table: "Feeders");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Feeders",
                newName: "ReactionTime");
        }
    }
}
