using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_With_Angular.Migrations
{
    /// <inheritdoc />
    public partial class Initdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblLogin",
                table: "tblLogin");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "tblLogin",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tblLogin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "tblLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "tblLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "tblLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblLogin",
                table: "tblLogin",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblLogin",
                table: "tblLogin");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "tblLogin");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tblLogin");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "tblLogin");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblLogin");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "tblLogin");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "tblLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblLogin",
                table: "tblLogin",
                column: "Id");
        }
    }
}
