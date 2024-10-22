using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShenzhenLhgs.Migrations
{
    /// <inheritdoc />
    public partial class AddNumpaixNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Xingm",
                table: "GzfRankings",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sfzh",
                table: "GzfRankings",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Numpaix",
                table: "GzfRankings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Xingm",
                table: "AjfRankings",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sfzh",
                table: "AjfRankings",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GzfRankings_Sfzh",
                table: "GzfRankings",
                column: "Sfzh");

            migrationBuilder.CreateIndex(
                name: "IX_GzfRankings_Xingm",
                table: "GzfRankings",
                column: "Xingm");

            migrationBuilder.CreateIndex(
                name: "IX_AjfRankings_Sfzh",
                table: "AjfRankings",
                column: "Sfzh");

            migrationBuilder.CreateIndex(
                name: "IX_AjfRankings_Xingm",
                table: "AjfRankings",
                column: "Xingm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GzfRankings_Sfzh",
                table: "GzfRankings");

            migrationBuilder.DropIndex(
                name: "IX_GzfRankings_Xingm",
                table: "GzfRankings");

            migrationBuilder.DropIndex(
                name: "IX_AjfRankings_Sfzh",
                table: "AjfRankings");

            migrationBuilder.DropIndex(
                name: "IX_AjfRankings_Xingm",
                table: "AjfRankings");

            migrationBuilder.AlterColumn<string>(
                name: "Xingm",
                table: "GzfRankings",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sfzh",
                table: "GzfRankings",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Numpaix",
                table: "GzfRankings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Xingm",
                table: "AjfRankings",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sfzh",
                table: "AjfRankings",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
