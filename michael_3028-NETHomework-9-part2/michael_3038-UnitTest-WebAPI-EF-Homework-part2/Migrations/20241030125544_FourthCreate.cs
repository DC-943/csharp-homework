using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace michael_3038EFWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FourthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categorylevel",
                table: "Categorys",
                newName: "CategoryLevel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryLevel",
                table: "Categorys",
                newName: "Categorylevel");
        }
    }
}
