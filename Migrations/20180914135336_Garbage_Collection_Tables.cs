using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tv.Migrations
{
    public partial class Garbage_Collection_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TvShows",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Garbages",
                columns: table => new
                {
                    GCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    RecyclingQty = table.Column<int>(nullable: false),
                    SubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garbages", x => x.GCId);
                });

            migrationBuilder.CreateTable(
                name: "GCSubCategories",
                columns: table => new
                {
                    SubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    GarbageModelGCId = table.Column<int>(nullable: true),
                    SubCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCSubCategories", x => x.SubId);
                    table.ForeignKey(
                        name: "FK_GCSubCategories_Garbages_GarbageModelGCId",
                        column: x => x.GarbageModelGCId,
                        principalTable: "Garbages",
                        principalColumn: "GCId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GCCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    GCSubCategorySubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCCategories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_GCCategories_GCSubCategories_GCSubCategorySubId",
                        column: x => x.GCSubCategorySubId,
                        principalTable: "GCSubCategories",
                        principalColumn: "SubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GCCategories_GCSubCategorySubId",
                table: "GCCategories",
                column: "GCSubCategorySubId");

            migrationBuilder.CreateIndex(
                name: "IX_GCSubCategories_GarbageModelGCId",
                table: "GCSubCategories",
                column: "GarbageModelGCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GCCategories");

            migrationBuilder.DropTable(
                name: "GCSubCategories");

            migrationBuilder.DropTable(
                name: "Garbages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TvShows",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
