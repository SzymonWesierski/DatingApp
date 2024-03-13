using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class MessageEntity_RecipientUsernameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipienUsername",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipienUsername",
                table: "Messages");
        }
    }
}
