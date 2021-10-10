using Microsoft.EntityFrameworkCore.Migrations;

namespace pp_test.Migrations
{
    public partial class Change4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Postamat_PostamaNum",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postamat",
                table: "Postamat");

            migrationBuilder.RenameTable(
                name: "Postamat",
                newName: "Postamats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postamats",
                table: "Postamats",
                column: "Num");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Postamats_PostamaNum",
                table: "Orders",
                column: "PostamaNum",
                principalTable: "Postamats",
                principalColumn: "Num",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Postamats_PostamaNum",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postamats",
                table: "Postamats");

            migrationBuilder.RenameTable(
                name: "Postamats",
                newName: "Postamat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postamat",
                table: "Postamat",
                column: "Num");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Postamat_PostamaNum",
                table: "Orders",
                column: "PostamaNum",
                principalTable: "Postamat",
                principalColumn: "Num",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
