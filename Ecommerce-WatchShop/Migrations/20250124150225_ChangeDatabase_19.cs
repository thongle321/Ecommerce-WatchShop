using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_WatchShop.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabase_19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Bills",
                type: "nvarchar(255)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Bills");
        }
    }
}
