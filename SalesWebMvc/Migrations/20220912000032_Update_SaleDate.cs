using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class Update_SaleDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Seller",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
