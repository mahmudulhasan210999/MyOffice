using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOffice.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpJoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpDoB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpBloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpInfos");
        }
    }
}
