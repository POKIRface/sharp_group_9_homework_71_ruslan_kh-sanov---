using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task1.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Subscribers2",
                table: "AspNetUsers",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscribers2",
                table: "AspNetUsers");
        }
    }
}
