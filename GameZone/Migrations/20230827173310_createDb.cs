using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CoverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbGames_TbCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TbCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbGameDevices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGameDevices", x => new { x.GameId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_TbGameDevices_TbDevices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "TbDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbGameDevices_TbGames_GameId",
                        column: x => x.GameId,
                        principalTable: "TbGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TbCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sport" },
                    { 2, "Action" },
                    { 3, "Film" },
                    { 4, "Story" }
                });

            migrationBuilder.InsertData(
                table: "TbDevices",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "bi bi-playstation", "Playstation" },
                    { 2, "bi bi-xbox", "Xbox" },
                    { 3, "bi bi-pc-display", "PC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbGameDevices_DeviceId",
                table: "TbGameDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_TbGames_CategoryId",
                table: "TbGames",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbGameDevices");

            migrationBuilder.DropTable(
                name: "TbDevices");

            migrationBuilder.DropTable(
                name: "TbGames");

            migrationBuilder.DropTable(
                name: "TbCategory");
        }
    }
}
