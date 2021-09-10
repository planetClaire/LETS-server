using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Migrations
{
    public partial class RemoveMemberTypeFromMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberTypeId",
                table: "Members",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberTypeId",
                table: "Members",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
