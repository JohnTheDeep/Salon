using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonApp.Migrations
{
    public partial class intial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duty_Id",
                table: "AvanciesT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duty_Id",
                table: "AvanciesT");
        }
    }
}
