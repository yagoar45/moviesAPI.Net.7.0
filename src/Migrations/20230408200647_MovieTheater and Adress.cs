using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPIVscode.Migrations
{
    /// <inheritdoc />
    public partial class MovieTheaterandAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "MovieTheaters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_AdressId",
                table: "MovieTheaters",
                column: "AdressId");

        
            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Adresses_AdressId",
                table: "MovieTheaters",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Adresses_AdressId",
                table: "MovieTheaters");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheaters_AdressId",
                table: "MovieTheaters");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "MovieTheaters");
        }
    }
}
