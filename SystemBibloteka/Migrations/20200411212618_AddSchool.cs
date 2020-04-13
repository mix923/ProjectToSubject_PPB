using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemBibloteka.Migrations
{
    public partial class AddSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Library",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Library",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Side",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Library_SchoolId",
                table: "Library",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_School_SchoolId",
                table: "Library",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_School_SchoolId",
                table: "Library");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropIndex(
                name: "IX_Library_SchoolId",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Side",
                table: "Book");
        }
    }
}
