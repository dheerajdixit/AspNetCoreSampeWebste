using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoManager.Migrations
{
    public partial class UniquePhotoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniquePhotoName",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniquePhotoName",
                table: "Photos");
        }
    }
}
