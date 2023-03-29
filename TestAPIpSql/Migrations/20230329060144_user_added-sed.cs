using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestAPISql.Migrations
{
    /// <inheritdoc />
    public partial class user_addedsed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password", "Token" },
                values: new object[,]
                {
                    { 1, "test@mail.ru", "My_Log!n", "Test1", "Password!1234", "123dswqefdfae3fgq" },
                    { 2, "test@mail.ru", "My_Log!n", "Test2", "Password!1234", "123dswqefdfae3fgq" },
                    { 3, "test@mail.ru", "My_Log!n", "Test3", "Password!1234", "123dswqefdfae3fgq" },
                    { 4, "test@mail.ru", "My_Log!n", "Test4", "Password!1234", "123dswqefdfae3fgq" },
                    { 5, "test@mail.ru", "My_Log!n", "Test5", "Password!1234", "123dswqefdfae3fgq" },
                    { 6, "test@mail.ru", "My_Log!n", "Test6", "Password!1234", "123dswqefdfae3fgq" },
                    { 7, "test@mail.ru", "My_Log!n", "Test7", "Password!1234", "123dswqefdfae3fgq" },
                    { 8, "test@mail.ru", "My_Log!n", "Test8", "Password!1234", "123dswqefdfae3fgq" },
                    { 9, "test@mail.ru", "My_Log!n", "Test9", "Password!1234", "123dswqefdfae3fgq" },
                    { 10, "test@mail.ru", "My_Log!n", "Test10", "Password!1234", "123dswqefdfae3fgq" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
