using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalRadiation.WebApi.Migrations
{
    public partial class bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_Categories_CategoriesId",
                table: "NewsItems");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CategoriesId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "NewsItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "NewsItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CategoriesId",
                table: "NewsItems",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_Categories_CategoriesId",
                table: "NewsItems",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
