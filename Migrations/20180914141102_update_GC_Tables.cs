using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tv.Migrations
{
    public partial class update_GC_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GCCategories_GCSubCategories_GCSubCategorySubId",
                table: "GCCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_GCSubCategories_Garbages_GarbageModelGCId",
                table: "GCSubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GCSubCategories",
                table: "GCSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_GCSubCategories_GarbageModelGCId",
                table: "GCSubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GCCategories",
                table: "GCCategories");

            migrationBuilder.DropIndex(
                name: "IX_GCCategories_GCSubCategorySubId",
                table: "GCCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Garbages",
                table: "Garbages");

            migrationBuilder.DropColumn(
                name: "GarbageModelGCId",
                table: "GCSubCategories");

            migrationBuilder.DropColumn(
                name: "GCSubCategorySubId",
                table: "GCCategories");

            migrationBuilder.RenameTable(
                name: "GCSubCategories",
                newName: "GC_Sub_Category");

            migrationBuilder.RenameTable(
                name: "GCCategories",
                newName: "GC_Category");

            migrationBuilder.RenameTable(
                name: "Garbages",
                newName: "Garbage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GC_Sub_Category",
                table: "GC_Sub_Category",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GC_Category",
                table: "GC_Category",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Garbage",
                table: "Garbage",
                column: "GCId");

            migrationBuilder.CreateIndex(
                name: "IX_GC_Sub_Category_CategoryId",
                table: "GC_Sub_Category",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Garbage_SubId",
                table: "Garbage",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garbage_GC_Sub_Category_SubId",
                table: "Garbage",
                column: "SubId",
                principalTable: "GC_Sub_Category",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GC_Sub_Category_GC_Category_CategoryId",
                table: "GC_Sub_Category",
                column: "CategoryId",
                principalTable: "GC_Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garbage_GC_Sub_Category_SubId",
                table: "Garbage");

            migrationBuilder.DropForeignKey(
                name: "FK_GC_Sub_Category_GC_Category_CategoryId",
                table: "GC_Sub_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GC_Sub_Category",
                table: "GC_Sub_Category");

            migrationBuilder.DropIndex(
                name: "IX_GC_Sub_Category_CategoryId",
                table: "GC_Sub_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GC_Category",
                table: "GC_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Garbage",
                table: "Garbage");

            migrationBuilder.DropIndex(
                name: "IX_Garbage_SubId",
                table: "Garbage");

            migrationBuilder.RenameTable(
                name: "GC_Sub_Category",
                newName: "GCSubCategories");

            migrationBuilder.RenameTable(
                name: "GC_Category",
                newName: "GCCategories");

            migrationBuilder.RenameTable(
                name: "Garbage",
                newName: "Garbages");

            migrationBuilder.AddColumn<int>(
                name: "GarbageModelGCId",
                table: "GCSubCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GCSubCategorySubId",
                table: "GCCategories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GCSubCategories",
                table: "GCSubCategories",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GCCategories",
                table: "GCCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Garbages",
                table: "Garbages",
                column: "GCId");

            migrationBuilder.CreateIndex(
                name: "IX_GCSubCategories_GarbageModelGCId",
                table: "GCSubCategories",
                column: "GarbageModelGCId");

            migrationBuilder.CreateIndex(
                name: "IX_GCCategories_GCSubCategorySubId",
                table: "GCCategories",
                column: "GCSubCategorySubId");

            migrationBuilder.AddForeignKey(
                name: "FK_GCCategories_GCSubCategories_GCSubCategorySubId",
                table: "GCCategories",
                column: "GCSubCategorySubId",
                principalTable: "GCSubCategories",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GCSubCategories_Garbages_GarbageModelGCId",
                table: "GCSubCategories",
                column: "GarbageModelGCId",
                principalTable: "Garbages",
                principalColumn: "GCId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
