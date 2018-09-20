using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tv.Migrations
{
    public partial class UpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_GC_Category",
                table: "GC_Category");

            migrationBuilder.RenameTable(
                name: "GC_Sub_Category",
                newName: "SubCategory");

            migrationBuilder.RenameTable(
                name: "GC_Category",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_GC_Sub_Category_CategoryId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garbage_SubCategory_SubId",
                table: "Garbage",
                column: "SubId",
                principalTable: "SubCategory",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garbage_SubCategory_SubId",
                table: "Garbage");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "GC_Sub_Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "GC_Category");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_CategoryId",
                table: "GC_Sub_Category",
                newName: "IX_GC_Sub_Category_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GC_Sub_Category",
                table: "GC_Sub_Category",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GC_Category",
                table: "GC_Category",
                column: "CategoryId");

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
    }
}
