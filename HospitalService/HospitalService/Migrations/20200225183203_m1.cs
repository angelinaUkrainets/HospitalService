using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalService.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfile_Sicknesses_SicknessId",
                table: "BaseProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfile_VisitRequests_VisitId",
                table: "BaseProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfile_Sicknesses_SicknessId",
                table: "BaseProfile",
                column: "SicknessId",
                principalTable: "Sicknesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfile_VisitRequests_VisitId",
                table: "BaseProfile",
                column: "VisitId",
                principalTable: "VisitRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfile_Sicknesses_SicknessId",
                table: "BaseProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfile_VisitRequests_VisitId",
                table: "BaseProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfile_Sicknesses_SicknessId",
                table: "BaseProfile",
                column: "SicknessId",
                principalTable: "Sicknesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfile_VisitRequests_VisitId",
                table: "BaseProfile",
                column: "VisitId",
                principalTable: "VisitRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
