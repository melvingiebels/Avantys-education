﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyProgramManagement.Infrastructure.Context;

#nullable disable

namespace StudyProgramManagement.Commands.Migrations
{
    [DbContext(typeof(StudyProgramManagementDbContext))]
    [Migration("20230601213416_ChangedLectureFromScheduleToOptional")]
    partial class ChangedLectureFromScheduleToOptional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassNotation")
                        .HasColumnType("int");

                    b.Property<Guid?>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.LecturesSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateScheduled")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<Guid>("LectureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("LecturesSchedule");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ECs")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudyProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudyProgramId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudyProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudyProgramId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.StudyProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalECs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StudyPrograms");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.TeacherModules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherModules");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Class", b =>
                {
                    b.HasOne("StudyProgramManagement.Domain.Models.Module", null)
                        .WithMany("Classes")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Lecture", b =>
                {
                    b.HasOne("StudyProgramManagement.Domain.Models.Module", "Module")
                        .WithMany("Lectures")
                        .HasForeignKey("ModuleId");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.LecturesSchedule", b =>
                {
                    b.HasOne("StudyProgramManagement.Domain.Models.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Module", b =>
                {
                    b.HasOne("StudyProgramManagement.Domain.Models.StudyProgram", null)
                        .WithMany("Modules")
                        .HasForeignKey("StudyProgramId");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Student", b =>
                {
                    b.HasOne("StudyProgramManagement.Domain.Models.Class", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("StudyProgramManagement.Domain.Models.StudyProgram", null)
                        .WithMany("Students")
                        .HasForeignKey("StudyProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.TeacherModules", b =>
                {
                    b.HasOne("StudyProgramManagement.Domain.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyProgramManagement.Domain.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.Module", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("StudyProgramManagement.Domain.Models.StudyProgram", b =>
                {
                    b.Navigation("Modules");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
