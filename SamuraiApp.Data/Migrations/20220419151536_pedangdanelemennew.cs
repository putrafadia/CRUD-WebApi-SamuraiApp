using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class pedangdanelemennew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    elemen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pedangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_elements_pedangs_pedangId",
                        column: x => x.pedangId,
                        principalTable: "pedangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_elements_pedangId",
                table: "elements",
                column: "pedangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
