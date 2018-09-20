using Microsoft.EntityFrameworkCore.Migrations;

namespace Tv.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO TvNetworks (Name) VALUES ('Netflix')");
            migrationBuilder.Sql("INSERT INTO TvNetworks (Name) VALUES ('HBO')");
            migrationBuilder.Sql("INSERT INTO TvNetworks (Name) VALUES ('CBS')");
            migrationBuilder.Sql("INSERT INTO TvNetworks (Name) VALUES ('NBC')");

            // migrationBuilder.Sql("INSERT INTO GCCategory (CategoryName) VALUES ('可回收垃圾')");
            // migrationBuilder.Sql("INSERT INTO GCCategory (CategoryName) VALUES ('厨余垃圾')");
            // migrationBuilder.Sql("INSERT INTO GCCategory (CategoryName) VALUES ('有害垃圾')");
            // migrationBuilder.Sql("INSERT INTO GCCategory (CategoryName) VALUES ('其他垃圾')");

            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('House of Cards', (SELECT Id FROM TvNetworks WHERE Name='Netflix'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Altered Carbon', (SELECT Id FROM TvNetworks WHERE Name='Netflix'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Marvel''s Daredevil', (SELECT Id FROM TvNetworks WHERE Name='Netflix'))");

            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Game of Thrones', (SELECT Id FROM TvNetworks WHERE Name='HBO'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Silicon Valley', (SELECT Id FROM TvNetworks WHERE Name='HBO'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Veep', (SELECT Id FROM TvNetworks WHERE Name='HBO'))");

            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('NCIS', (SELECT Id FROM TvNetworks WHERE Name='CBS'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('The Big Bang Theory', (SELECT Id FROM TvNetworks WHERE Name='CBS'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Criminal Minds', (SELECT Id FROM TvNetworks WHERE Name='CBS'))");

            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Friends', (SELECT Id FROM TvNetworks WHERE Name='NBC'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Chicago Fire', (SELECT Id FROM TvNetworks WHERE Name='NBC'))");
            migrationBuilder.Sql("INSERT INTO TvShows (Name, TvNetworkId) VALUES ('Will & Grace', (SELECT Id FROM TvNetworks WHERE Name='NBC'))");

            
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废纸(废纸盒<黄板纸、花纸>、废报纸、废纸张、碎纸)', (SELECT CategoryId FROM GCCategory WHERE CategoryName='可回收垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废塑料(饮料瓶、塑料包装物、塑料制品)', (SELECT CategoryId FROM GCCategory WHERE CategoryName='可回收垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('金属(废铁及废铁制品、废铝及废铝制品、废铜及废铜制品、合金及合金制品等)', (SELECT CategoryId FROM GCCategory WHERE CategoryName='可回收垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废玻璃(玻璃瓶、碎玻璃、玻璃制品)；纺织物(旧衣物、纺织物)', (SELECT CategoryId FROM GCCategory WHERE CategoryName='可回收垃圾'))");

            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('骨头类', (SELECT CategoryId FROM GCCategory WHERE CategoryName='厨余垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('厨余干类', (SELECT CategoryId FROM GCCategory WHERE CategoryName='厨余垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('厨余湿类', (SELECT CategoryId FROM GCCategory WHERE CategoryName='厨余垃圾'))");
            
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废电池', (SELECT CategoryId FROM GCCategory WHERE CategoryName='有害垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废荧光灯管', (SELECT CategoryId FROM GCCategory WHERE CategoryName='有害垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('过期药品', (SELECT CategoryId FROM GCCategory WHERE CategoryName='有害垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废水银温度计血压计', (SELECT CategoryId FROM GCCategory WHERE CategoryName='有害垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('废家电（电视、洗衣机、冰箱、空调、电脑、其他家用电器）', (SELECT CategoryId FROM GCCategory WHERE CategoryName='有害垃圾'))");
            // migrationBuilder.Sql("INSERT INTO GCSubCategory(SubCategoryName, CategoryId) VALUES ('一次性餐具、纸巾、清扫物等', (SELECT CategoryId FROM GCCategory WHERE CategoryName='其他垃圾'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TvNetworks WHERE Name IN ('Netflix', 'HBO', 'CBS', 'NBC')");
            // migrationBuilder.Sql("DELETE FROM GCCategory WHERE Name IN ('可回收垃圾', '厨余垃圾', '有害垃圾', '其他垃圾')");
        }
    }
}
