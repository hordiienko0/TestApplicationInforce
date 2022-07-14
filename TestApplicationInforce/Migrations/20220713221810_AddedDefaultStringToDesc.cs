using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApplicationInforce.Migrations
{
    public partial class AddedDefaultStringToDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortedUrl",
                table: "Urls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortedUrl",
                table: "Urls");
        }
    }
}
