using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "Id", "Balance", "Name" },
                values: new object[,]
                {
                    { 1, 0m, "Tele2" },
                    { 2, 0m, "Beeline" }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Balance", "PropsId", "ServiceProviderId" },
                values: new object[,]
                {
                    { 1, 0m, 12345, 1 },
                    { 2, 0m, 54321, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
