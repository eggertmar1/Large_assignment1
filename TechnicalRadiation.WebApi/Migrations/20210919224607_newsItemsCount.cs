using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalRadiation.WebApi.Migrations
{
    public partial class newsItemsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_NewsItems_NewsItemsId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_NewsItems_NewsItemsId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NewsItemsId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Authors_NewsItemsId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "NewsItemsId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NewsItemsId",
                table: "Authors");

            migrationBuilder.CreateTable(
                name: "AuthorsNewsItems",
                columns: table => new
                {
                    AuthorLinkId = table.Column<int>(type: "INTEGER", nullable: false),
                    NewsItemsLinkId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsNewsItems", x => new { x.AuthorLinkId, x.NewsItemsLinkId });
                    table.ForeignKey(
                        name: "FK_AuthorsNewsItems_Authors_AuthorLinkId",
                        column: x => x.AuthorLinkId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsNewsItems_NewsItems_NewsItemsLinkId",
                        column: x => x.NewsItemsLinkId,
                        principalTable: "NewsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNewsItem_NewsItemsId",
                table: "CategoryNewsItem",
                column: "NewsItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorNewsItem_NewsItemsId",
                table: "AuthorNewsItem",
                column: "NewsItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsNewsItems_NewsItemsLinkId",
                table: "AuthorsNewsItems",
                column: "NewsItemsLinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorNewsItem_Authors_AuthorsId",
                table: "AuthorNewsItem",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorNewsItem_NewsItems_NewsItemsId",
                table: "AuthorNewsItem",
                column: "NewsItemsId",
                principalTable: "NewsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNewsItem_Categories_CategoriesId",
                table: "CategoryNewsItem",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNewsItem_NewsItems_NewsItemsId",
                table: "CategoryNewsItem",
                column: "NewsItemsId",
                principalTable: "NewsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorNewsItem_Authors_AuthorsId",
                table: "AuthorNewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorNewsItem_NewsItems_NewsItemsId",
                table: "AuthorNewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNewsItem_Categories_CategoriesId",
                table: "CategoryNewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNewsItem_NewsItems_NewsItemsId",
                table: "CategoryNewsItem");

            migrationBuilder.DropTable(
                name: "AuthorsNewsItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryNewsItem_NewsItemsId",
                table: "CategoryNewsItem");

            migrationBuilder.DropIndex(
                name: "IX_AuthorNewsItem_NewsItemsId",
                table: "AuthorNewsItem");

            migrationBuilder.AddColumn<int>(
                name: "NewsItemsId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewsItemsId",
                table: "Authors",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NewsItemsId",
                table: "Categories",
                column: "NewsItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_NewsItemsId",
                table: "Authors",
                column: "NewsItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_NewsItems_NewsItemsId",
                table: "Authors",
                column: "NewsItemsId",
                principalTable: "NewsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_NewsItems_NewsItemsId",
                table: "Categories",
                column: "NewsItemsId",
                principalTable: "NewsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
