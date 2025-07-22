using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SentToUserId",
                table: "Notifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Notifications",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Notifications",
                newName: "SentToUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Notifications",
                newName: "SentAt");
        }
    }
}
