using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Migrations
{
    public partial class ReallyRemoveMemberType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "MemberTypes");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberTypeId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberTypeId",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MemberTypeId",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberTypeId",
                table: "Members",
                column: "MemberTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
