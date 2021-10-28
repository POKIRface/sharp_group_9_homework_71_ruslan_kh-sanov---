using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task1.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Subscriptions2",
                table: "AspNetUsers",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscriptions2",
                table: "AspNetUsers");
        }
    }
}
