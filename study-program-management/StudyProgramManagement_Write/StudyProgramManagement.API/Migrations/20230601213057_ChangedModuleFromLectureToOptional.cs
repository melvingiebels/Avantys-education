using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyProgramManagement.Commands.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModuleFromLectureToOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Modules_ModuleId",
                table: "Lectures");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuleId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Modules_ModuleId",
                table: "Lectures",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Modules_ModuleId",
                table: "Lectures");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuleId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Modules_ModuleId",
                table: "Lectures",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
