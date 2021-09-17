using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalRadiation.WebApi.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryNewsItem",
                table: "CategoryNewsItem",
                columns: new[] { "CategoriesId", "NewsItemsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorNewsItem",
                table: "AuthorNewsItem",
                columns: new[] { "AuthorsId", "NewsItemsId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryNewsItem",
                table: "CategoryNewsItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorNewsItem",
                table: "AuthorNewsItem");
        }
    }
}
