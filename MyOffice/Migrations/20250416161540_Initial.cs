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
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpJoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
