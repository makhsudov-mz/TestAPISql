using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestAPISql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Login = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Token = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_users_Id",
                table: "users",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
