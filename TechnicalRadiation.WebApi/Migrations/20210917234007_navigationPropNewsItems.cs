using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalRadiation.WebApi.Migrations
{
    public partial class navigationPropNewsItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
