﻿// <auto-generated />
using System;
using Admin_Panel_ITI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Admin_Panel_ITI.Migrations
{
    [DbContext(typeof(MainDBContext))]
    [Migration("20230915115237_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Admin_Panel_ITI.Models.Admin", b =>
                {
                    b.Property<string>("AspNetUserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AspNetUserID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.CourseDay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("date");

                    b.Property<string>("TaskPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CourseDay");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Course_Day_Material", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("CourseDayID")
                        .HasColumnType("int");

                    b.Property<int>("MaterialID")
                        .HasColumnType("int");

                    b.HasKey("CourseID", "CourseDayID", "MaterialID");

                    b.HasIndex("CourseDayID");

                    b.HasIndex("MaterialID");

                    b.ToTable("Course_Day_Material");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("InstructorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam_Question", b =>
                {
                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("ExamID", "QuestionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Exam_Question");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam_Std_Question", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<string>("StudentAnswer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StudentGrade")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "QuestionID", "ExamID");

                    b.HasIndex("ExamID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Std_Quest_Exam");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Instructor", b =>
                {
                    b.Property<string>("AspNetUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<bool>("CurrentlyWorking")
                        .HasColumnType("bit");

                    b.HasKey("AspNetUserID");

                    b.HasIndex("AdminID");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Instructor_Course", b =>
                {
                    b.Property<string>("InstructorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.HasKey("InstructorID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("Instructor_Course");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Intake");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake_Instructor", b =>
                {
                    b.Property<string>("InstructorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IntakeID")
                        .HasColumnType("int");

                    b.HasKey("InstructorID", "IntakeID");

                    b.HasIndex("IntakeID");

                    b.ToTable("Intake_Instructors");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake_Track_Course", b =>
                {
                    b.Property<int>("IntakeID")
                        .HasColumnType("int");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("numOfStudentsInCourse")
                        .HasColumnType("int");

                    b.HasKey("IntakeID", "TrackID", "CourseID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TrackID");

                    b.ToTable("Intake_Track_Courses");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("InstructorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Mark")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student", b =>
                {
                    b.Property<string>("AspNetUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("IntakeID")
                        .HasColumnType("int");

                    b.Property<bool>("IsGraduated")
                        .HasColumnType("bit");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.HasKey("AspNetUserID");

                    b.HasIndex("AdminID");

                    b.HasIndex("IntakeID");

                    b.HasIndex("TrackID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student_Course", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("Student_Course");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student_Submission", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseDayID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<double>("SubmissionGrade")
                        .HasColumnType("float");

                    b.Property<string>("SubmissionPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID", "CourseDayID");

                    b.HasIndex("CourseDayID");

                    b.ToTable("Student_Submission");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Track", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("ManagerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Admin", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.AppUser", "AspNetUser")
                        .WithMany("Admins")
                        .HasForeignKey("AspNetUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AspNetUser");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Course", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Course_Day_Material", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.CourseDay", "CourseDay")
                        .WithMany("CourseDayMaterials")
                        .HasForeignKey("CourseDayID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Course", "Course")
                        .WithMany("CourseDayMaterials")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Material", "MaterialOfDay")
                        .WithMany("CourseDayMaterials")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseDay");

                    b.Navigation("MaterialOfDay");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseID");

                    b.HasOne("Admin_Panel_ITI.Models.Instructor", "Instructor")
                        .WithMany("Exams")
                        .HasForeignKey("InstructorID");

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam_Question", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Exam", "Exam")
                        .WithMany("Exam_Question")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Question", "Question")
                        .WithMany("Exam_Question")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam_Std_Question", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Exam", "Exam")
                        .WithMany("Student_Quest_Exam")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Question", "Question")
                        .WithMany("Student_Quest_Exam")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Student", "Student")
                        .WithMany("Student_Quest_Exam")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Instructor", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.AppUser", "Admin")
                        .WithMany("Instructors_Admin")
                        .HasForeignKey("AdminID");

                    b.HasOne("Admin_Panel_ITI.Models.AppUser", "AspNetUser")
                        .WithMany("Instructors_AspNetUser")
                        .HasForeignKey("AspNetUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("AspNetUser");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Instructor_Course", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Course", "Course")
                        .WithMany("InstructorCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Instructor", "Instructor")
                        .WithMany("InstructorCourses")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Admin", "Admin")
                        .WithMany("Intakes")
                        .HasForeignKey("AdminID");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake_Instructor", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Instructor", "Instructor")
                        .WithMany("IntakeInstructors")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Intake", "Intake")
                        .WithMany("IntakeInstructors")
                        .HasForeignKey("IntakeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Intake");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake_Track_Course", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Course", "Course")
                        .WithMany("IntakeTrackCourse")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Intake", "Intake")
                        .WithMany("IntakeTrackCourse")
                        .HasForeignKey("IntakeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Track", "Track")
                        .WithMany("IntakeTrackCourse")
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Intake");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Material", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Instructor", "Instructor")
                        .WithMany("Materials")
                        .HasForeignKey("InstructorID");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.AppUser", "Admin")
                        .WithMany("Students_Admin")
                        .HasForeignKey("AdminID");

                    b.HasOne("Admin_Panel_ITI.Models.AppUser", "AspNetUser")
                        .WithMany("Students_AspNetUser")
                        .HasForeignKey("AspNetUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Intake", "Intake")
                        .WithMany("Students")
                        .HasForeignKey("IntakeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("AspNetUser");

                    b.Navigation("Intake");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student_Course", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student_Submission", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.CourseDay", "CourseDay")
                        .WithMany("StudentsSubmissions")
                        .HasForeignKey("CourseDayID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.Student", "Student")
                        .WithMany("StudentsSubmissions")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CourseDay");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Track", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.Admin", "Admin")
                        .WithMany("Tracks")
                        .HasForeignKey("AdminID");

                    b.HasOne("Admin_Panel_ITI.Models.Instructor", "Manager")
                        .WithMany("Tracks")
                        .HasForeignKey("ManagerID");

                    b.Navigation("Admin");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Admin_Panel_ITI.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Admin_Panel_ITI.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Admin", b =>
                {
                    b.Navigation("Intakes");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.AppUser", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Instructors_Admin");

                    b.Navigation("Instructors_AspNetUser");

                    b.Navigation("Students_Admin");

                    b.Navigation("Students_AspNetUser");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Course", b =>
                {
                    b.Navigation("CourseDayMaterials");

                    b.Navigation("Exams");

                    b.Navigation("InstructorCourses");

                    b.Navigation("IntakeTrackCourse");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.CourseDay", b =>
                {
                    b.Navigation("CourseDayMaterials");

                    b.Navigation("StudentsSubmissions");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Exam", b =>
                {
                    b.Navigation("Exam_Question");

                    b.Navigation("Student_Quest_Exam");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Instructor", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("InstructorCourses");

                    b.Navigation("IntakeInstructors");

                    b.Navigation("Materials");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Intake", b =>
                {
                    b.Navigation("IntakeInstructors");

                    b.Navigation("IntakeTrackCourse");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Material", b =>
                {
                    b.Navigation("CourseDayMaterials");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Question", b =>
                {
                    b.Navigation("Exam_Question");

                    b.Navigation("Student_Quest_Exam");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("Student_Quest_Exam");

                    b.Navigation("StudentsSubmissions");
                });

            modelBuilder.Entity("Admin_Panel_ITI.Models.Track", b =>
                {
                    b.Navigation("IntakeTrackCourse");
                });
#pragma warning restore 612, 618
        }
    }
}
