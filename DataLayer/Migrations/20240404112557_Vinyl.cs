using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Vinyl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Vinyl_VinylId",
                table: "Author");

            migrationBuilder.DropTable(
                name: "AuthorProducer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_VinylId",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vinyl",
                newName: "VinylId");

            migrationBuilder.RenameColumn(
                name: "VinylId",
                table: "Author",
                newName: "AuthorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrackId",
                table: "Tracks",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "VinylId",
                table: "Vinyl",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Author",
                newName: "VinylId");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Tracks",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Author",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorProducer",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducersProducerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorProducer", x => new { x.AuthorsId, x.ProducersProducerId });
                    table.ForeignKey(
                        name: "FK_AuthorProducer_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorProducer_Producer_ProducersProducerId",
                        column: x => x.ProducersProducerId,
                        principalTable: "Producer",
                        principalColumn: "ProducerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_VinylId",
                table: "Author",
                column: "VinylId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorProducer_ProducersProducerId",
                table: "AuthorProducer",
                column: "ProducersProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Vinyl_VinylId",
                table: "Author",
                column: "VinylId",
                principalTable: "Vinyl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
