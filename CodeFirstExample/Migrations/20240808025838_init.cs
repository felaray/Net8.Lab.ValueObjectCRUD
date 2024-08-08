using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirstExample.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_WorkItemId = table.Column<int>(type: "int", nullable: false),
                    Item_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_WorkTypeId = table.Column<int>(type: "int", nullable: false),
                    Item_WorkTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "維護" },
                    { 2, "開發" },
                    { 3, "測試" },
                    { 4, "部署" },
                    { 5, "分析" },
                    { 6, "設計" },
                    { 7, "管理" },
                    { 8, "支援" },
                    { 9, "研究" },
                    { 10, "其他" }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "Description", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, "修復系統錯誤", 1 },
                    { 2, "新增功能", 2 },
                    { 3, "測試功能", 3 },
                    { 4, "部署功能", 4 },
                    { 5, "分析需求", 5 },
                    { 6, "設計系統", 6 },
                    { 7, "管理專案", 7 },
                    { 8, "支援客戶", 8 },
                    { 9, "研究新技術", 9 },
                    { 10, "其他工作", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkTypeId",
                table: "WorkItems",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkTypes");
        }
    }
}
