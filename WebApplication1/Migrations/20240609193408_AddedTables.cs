using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MuzykAPBD",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MuzykAPBD_pk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "WytworniaAPBD",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WytworniaAPBD_pk", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "AlbumAPBD",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AlbumAPBD_pk", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "Album_WytworniaAPBD",
                        column: x => x.IdWytwornia,
                        principalTable: "WytworniaAPBD",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UtworAPBD",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<double>(type: "float", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UtworAPBD_pk", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "Utwor_AlbumAPBD",
                        column: x => x.IdAlbum,
                        principalTable: "AlbumAPBD",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WykonawcaUtworuAPBD",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WykonawcaUtworuAPBD_pk", x => new { x.IdUtwor, x.IdMuzyk });
                    table.ForeignKey(
                        name: "Muzyk_WykAPBD",
                        column: x => x.IdMuzyk,
                        principalTable: "MuzykAPBD",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Utwor_WykAPBD",
                        column: x => x.IdUtwor,
                        principalTable: "UtworAPBD",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumAPBD_IdWytwornia",
                table: "AlbumAPBD",
                column: "IdWytwornia");

            migrationBuilder.CreateIndex(
                name: "IX_UtworAPBD_IdAlbum",
                table: "UtworAPBD",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_WykonawcaUtworuAPBD_IdMuzyk",
                table: "WykonawcaUtworuAPBD",
                column: "IdMuzyk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawcaUtworuAPBD");

            migrationBuilder.DropTable(
                name: "MuzykAPBD");

            migrationBuilder.DropTable(
                name: "UtworAPBD");

            migrationBuilder.DropTable(
                name: "AlbumAPBD");

            migrationBuilder.DropTable(
                name: "WytworniaAPBD");
        }
    }
}
