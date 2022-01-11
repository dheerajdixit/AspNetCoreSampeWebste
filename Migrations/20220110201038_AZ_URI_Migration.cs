using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoManager.Migrations
{
    public partial class AZ_URI_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AZ_Photo_Uri",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AZ_Photo_Uri",
                table: "Photos");
        }
    }
}
