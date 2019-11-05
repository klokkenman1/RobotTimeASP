using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "Time", "Url" },
                values: new object[] { 1, "Exercise 1", 5, "https://cdn.discordapp.com/attachments/639062904020140034/641286527581683772/Standje_2.png" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "Time", "Url" },
                values: new object[] { 2, "Exercise 2", 5, "https://cdn.discordapp.com/attachments/639062904020140034/641286530186608644/Movement_1.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
