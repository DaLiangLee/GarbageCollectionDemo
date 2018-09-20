using Microsoft.EntityFrameworkCore.Migrations;

namespace Tv.Migrations
{
    public partial class SeedCategoryData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('可回收垃圾')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('厨余垃圾')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('有害垃圾')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('其他垃圾')");
            
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废纸(废纸盒<黄板纸、花纸>、废报纸、废纸张、碎纸)', (SELECT CategoryId FROM Category WHERE CategoryName='可回收垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废塑料(饮料瓶、塑料包装物、塑料制品)', (SELECT CategoryId FROM Category WHERE CategoryName='可回收垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('金属(废铁及废铁制品、废铝及废铝制品、废铜及废铜制品、合金及合金制品等)', (SELECT CategoryId FROM Category WHERE CategoryName='可回收垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废玻璃(玻璃瓶、碎玻璃、玻璃制品)；纺织物(旧衣物、纺织物)', (SELECT CategoryId FROM Category WHERE CategoryName='可回收垃圾'))");

            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('骨头类', (SELECT CategoryId FROM Category WHERE CategoryName='厨余垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('厨余干类', (SELECT CategoryId FROM Category WHERE CategoryName='厨余垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('厨余湿类', (SELECT CategoryId FROM Category WHERE CategoryName='厨余垃圾'))");
            
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废电池', (SELECT CategoryId FROM Category WHERE CategoryName='有害垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废荧光灯管', (SELECT CategoryId FROM Category WHERE CategoryName='有害垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('过期药品', (SELECT CategoryId FROM Category WHERE CategoryName='有害垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废水银温度计血压计', (SELECT CategoryId FROM Category WHERE CategoryName='有害垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('废家电（电视、洗衣机、冰箱、空调、电脑、其他家用电器）', (SELECT CategoryId FROM Category WHERE CategoryName='有害垃圾'))");
            migrationBuilder.Sql("INSERT INTO SubCategory(SubCategoryName, CategoryId) VALUES ('一次性餐具、纸巾、清扫物等', (SELECT CategoryId FROM Category WHERE CategoryName='其他垃圾'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Category WHERE Name IN ('可回收垃圾', '厨余垃圾', '有害垃圾', '其他垃圾')");
        }
    }
}
