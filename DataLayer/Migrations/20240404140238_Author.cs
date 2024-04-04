using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tracks",
                newName: "Title_track");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Vinyl",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VinylId",
                table: "Tracks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VinylId",
                table: "Author",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AuthorProducer",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorProducer", x => new { x.AuthorId, x.ProducerId });
                    table.ForeignKey(
                        name: "FK_AuthorProducer_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorProducer_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "ProducerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_AuthorId",
                table: "Vinyl",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_VinylId",
                table: "Tracks",
                column: "VinylId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorProducer_ProducerId",
                table: "AuthorProducer",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Vinyl_VinylId",
                table: "Tracks",
                column: "VinylId",
                principalTable: "Vinyl",
                principalColumn: "VinylId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vinyl_Author_AuthorId",
                table: "Vinyl",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Vinyl_VinylId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Vinyl_Author_AuthorId",
                table: "Vinyl");

            migrationBuilder.DropTable(
                name: "AuthorProducer");

            migrationBuilder.DropIndex(
                name: "IX_Vinyl_AuthorId",
                table: "Vinyl");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_VinylId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Vinyl");

            migrationBuilder.DropColumn(
                name: "VinylId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "VinylId",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "Title_track",
                table: "Tracks",
                newName: "Title");
        }
    }
}
