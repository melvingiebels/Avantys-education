using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSomeAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Tests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "Tests",
                type: "float",
                nullable: true);
        }
    }
}
