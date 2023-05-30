using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyProgramManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStudyProgramModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassId1",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StudyPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StudyPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudyProgramId",
                table: "Students",
                column: "StudyProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudyPrograms_StudyProgramId",
                table: "Students",
                column: "StudyProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudyPrograms_StudyProgramId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudyProgramId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "StudyPrograms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StudyPrograms");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId1",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId1",
                table: "Students",
                column: "ClassId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId1",
                table: "Students",
                column: "ClassId1",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
