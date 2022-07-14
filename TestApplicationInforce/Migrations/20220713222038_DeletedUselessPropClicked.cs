using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApplicationInforce.Migrations
{
    public partial class DeletedUselessPropClicked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clicked",
                table: "Urls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clicked",
                table: "Urls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
