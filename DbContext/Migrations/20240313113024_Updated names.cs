using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Updatednames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BookID",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Stores",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Stores",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stores",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stores",
                newName: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookID",
                table: "Authors",
                column: "BookID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
