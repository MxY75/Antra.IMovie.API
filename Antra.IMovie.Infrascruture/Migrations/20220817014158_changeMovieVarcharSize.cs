using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antra.IMovie.Infrascruture.Migrations
{
    public partial class changeMovieVarcharSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Movie",
                type: "Varchar(48)",
                maxLength: 48,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TmdbUrl",
                table: "Movie",
                type: "Varchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar");

            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Movie",
                type: "Varchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Overview",
                table: "Movie",
                type: "Varchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar");

            migrationBuilder.AlterColumn<string>(
                name: "ImdbUrl",
                table: "Movie",
                type: "Varchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Movie",
                type: "Varchar(48)",
                maxLength: 48,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackdropUrl",
                table: "Movie",
                type: "Varchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Movie",
                type: "Varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(48)",
                oldMaxLength: 48,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TmdbUrl",
                table: "Movie",
                type: "Varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Movie",
                type: "Varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "Overview",
                table: "Movie",
                type: "Varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "ImdbUrl",
                table: "Movie",
                type: "Varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Movie",
                type: "Varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(48)",
                oldMaxLength: 48,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackdropUrl",
                table: "Movie",
                type: "Varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(2048)",
                oldMaxLength: 2048);
        }
    }
}
