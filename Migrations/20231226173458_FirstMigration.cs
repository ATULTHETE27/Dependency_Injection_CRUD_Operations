using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netCoreMVCIntro.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Collage_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Collages_CollageId",
                        column: x => x.CollageId,
                        principalTable: "Collages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Collages",
                columns: new[] { "Id", "Address", "Code", "Collage_Name", "Grade" },
                values: new object[] { 1, "Adgoan", 4047, "MET", "B++" });

            migrationBuilder.InsertData(
                table: "Collages",
                columns: new[] { "Id", "Address", "Code", "Collage_Name", "Grade" },
                values: new object[] { 2, "Gangapur Road", 4039, "NDMVP", "A++" });

            migrationBuilder.InsertData(
                table: "Collages",
                columns: new[] { "Id", "Address", "Code", "Collage_Name", "Grade" },
                values: new object[] { 3, "Amrutdham", 4043, "KKW", "A++" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CollageId", "DOB", "First_Name", "Last_Name", "Percentage" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2003, 1, 27, 17, 20, 0, 0, DateTimeKind.Unspecified), "Atul", "Thete", 90 },
                    { 2, 1, new DateTime(2003, 1, 27, 17, 20, 0, 0, DateTimeKind.Unspecified), "Ankit", "Sharma", 85 },
                    { 3, 2, new DateTime(2002, 7, 2, 6, 50, 0, 0, DateTimeKind.Unspecified), "Pranjal", "Thorat", 88 },
                    { 4, 2, new DateTime(2002, 11, 6, 23, 20, 0, 0, DateTimeKind.Unspecified), "Aditi", "Bhawsar", 82 },
                    { 5, 3, new DateTime(2003, 2, 8, 9, 20, 0, 0, DateTimeKind.Unspecified), "Lalit", "Pagar", 89 },
                    { 6, 3, new DateTime(2002, 4, 6, 15, 20, 0, 0, DateTimeKind.Unspecified), "Abhijeet", "Bhaskar", 84 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollageId",
                table: "Students",
                column: "CollageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Collages");
        }
    }
}
