using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPISql.Migrations
{
    public partial class user_param_jsons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "param_jsons",
                table: "users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "param_jsons",
                table: "users");
        }
    }
}
