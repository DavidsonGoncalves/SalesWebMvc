using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartmentForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalessRecord_seller_Sellerid",
                table: "SalessRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_seller_Department_DepartmentId",
                table: "seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_seller",
                table: "seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalessRecord",
                table: "SalessRecord");

            migrationBuilder.RenameTable(
                name: "seller",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "SalessRecord",
                newName: "SalesRecord");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Seller",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_seller_DepartmentId",
                table: "Seller",
                newName: "IX_Seller_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_SalessRecord_Sellerid",
                table: "SalesRecord",
                newName: "IX_SalesRecord_Sellerid");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_Sellerid",
                table: "SalesRecord",
                column: "Sellerid",
                principalTable: "Seller",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentID",
                table: "Seller",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_Sellerid",
                table: "SalesRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentID",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "seller");

            migrationBuilder.RenameTable(
                name: "SalesRecord",
                newName: "SalessRecord");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "seller",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartmentID",
                table: "seller",
                newName: "IX_seller_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_Sellerid",
                table: "SalessRecord",
                newName: "IX_SalessRecord_Sellerid");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "seller",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_seller",
                table: "seller",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalessRecord",
                table: "SalessRecord",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalessRecord_seller_Sellerid",
                table: "SalessRecord",
                column: "Sellerid",
                principalTable: "seller",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_seller_Department_DepartmentId",
                table: "seller",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
