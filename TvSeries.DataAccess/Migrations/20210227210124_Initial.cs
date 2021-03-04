using Microsoft.EntityFrameworkCore.Migrations;

namespace TvSeries.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actors_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "Genres", "IsActive", "Name" },
                values: new object[] { 1, "Ross Geller, Rachel Green, Monica Geller, Joey Tribbiani, Chandler Bing, and Phoebe Buffay are six 20 something year olds living in New York City. Over the course of 10 years, these friends go through family, love, drama, friendship, and comedy.", "Comedy, Romance", false, "Friends" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "Genres", "IsActive", "Name" },
                values: new object[] { 2, "Ted Mosby sits down with his kids, to tell them the story of how he met their mother. The story is told through memories of his friends Marshall, Lily, Robin, and Barney Stinson. All legendary 9 seasons lead up to the moment of Ted's final encounter with the one.", "Comedy, Romance", false, "How I Met Your Mother" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "Genres", "IsActive", "Name" },
                values: new object[] { 3, "An innocent man is framed for the homicide of the Vice President's brother and scheduled to be executed at a super-max penitentiary, thus it's up to his younger brother to save him with his genius scheme: install himself in the same prison by holding up a bank and, as the final month ticks away, launch the escape plan step-by-step to break the both of them out, with his full-body tattoo acting as his guide; a tattoo which hides the layout of the prison facility and necessary clues vital to the escape.", "Action,Crime,Drama,Mystery,Thriller", false, "Prison Break" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name", "SeriesId", "Surname" },
                values: new object[,]
                {
                    { 1, "Matt", 1, "LeBlanc" },
                    { 2, "Matthew", 1, "Perry" },
                    { 3, "Courteney", 1, "Cox" },
                    { 4, "Neil Patrick", 2, "Harris" },
                    { 5, "Wentworth", 3, "Miller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_SeriesId",
                table: "Actors",
                column: "SeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
