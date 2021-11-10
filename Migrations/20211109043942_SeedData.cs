using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Solutions.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Author", "City", "Country", "Description", "Rating", "Title" },
                values: new object[] { 1, "James", "Bangkok", "Thailand", "lorem ipsum afdfadsfdsf", 3, "Best city " });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Author", "City", "Country", "Description", "Rating", "Title" },
                values: new object[] { 2, "Mike", "Paris", "France", "Lorem ipsum jklf;dajfl;adjfkl;djfklads;jf", 1, "Worst city" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Author", "City", "Country", "Description", "Rating", "Title" },
                values: new object[] { 4, "Shaun", "Tokyo", "Japan", "dklfajskfl;ajdk kdfal; jfk kl;adj fka;", 4, "A city" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 4);
        }
    }
}
