using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.API.Migrations
{
    public partial class AddDiscriptionFieldMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FieldMasters",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldMasters_Name",
                table: "FieldMasters",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FieldMasters_Name",
                table: "FieldMasters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FieldMasters");
        }
    }
}
