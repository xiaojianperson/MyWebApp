using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_web_app_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTodoItemStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "TodoItems");
        }
    }
}
