using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antra.IMovie.Infrascruture.Migrations
{
    public partial class changeReview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "Varchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "Varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);
        }
    }
}
