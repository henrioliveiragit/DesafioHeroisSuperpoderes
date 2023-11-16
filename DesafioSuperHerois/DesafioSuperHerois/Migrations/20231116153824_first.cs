using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioSuperHerois.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herois",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: true),
                    NomeHeroi = table.Column<string>(type: "varchar(120)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Altura = table.Column<decimal>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superpoderes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Superpoder = table.Column<string>(type: "varchar(50)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superpoderes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroisSuperpoderes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroiId = table.Column<int>(nullable: false),
                    HeroisId = table.Column<int>(nullable: true),
                    SuperpoderId = table.Column<int>(nullable: false),
                    SuperpoderesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisSuperpoderes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroisSuperpoderes_Herois_HeroisId",
                        column: x => x.HeroisId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeroisSuperpoderes_Superpoderes_SuperpoderesId",
                        column: x => x.SuperpoderesId,
                        principalTable: "Superpoderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperpoderes_HeroisId",
                table: "HeroisSuperpoderes",
                column: "HeroisId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperpoderes_SuperpoderesId",
                table: "HeroisSuperpoderes",
                column: "SuperpoderesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroisSuperpoderes");

            migrationBuilder.DropTable(
                name: "Herois");

            migrationBuilder.DropTable(
                name: "Superpoderes");
        }
    }
}
