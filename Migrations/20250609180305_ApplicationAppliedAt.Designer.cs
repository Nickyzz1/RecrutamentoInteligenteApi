﻿// <auto-generated />
using System;
using Api.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DaredeDbContext))]
    [Migration("20250609180305_ApplicationAppliedAt")]
    partial class ApplicationAppliedAt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AppliedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("applied_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("note");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<int>("candidate_id")
                        .HasColumnType("int");

                    b.Property<int?>("dismissal_stage_id")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Application");

                    b.HasIndex("candidate_id");

                    b.HasIndex("dismissal_stage_id");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_application", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("required");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredEducation");

                    b.HasIndex("VacancyId");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_desired_education", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("required");

                    b.Property<int>("Time")
                        .HasColumnType("int")
                        .HasColumnName("time");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredExperience");

                    b.HasIndex("VacancyId");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_desired_experience", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("required");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredLanguage");

                    b.HasIndex("VacancyId");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_desired_language", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("required");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredSkill");

                    b.HasIndex("VacancyId");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_desired_skill", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("course");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("institution");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Education");

                    b.HasIndex("UserId");

                    b.HasIndex("user_id");

                    b.ToTable("tb_education", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("company");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("location");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("role");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Experience");

                    b.HasIndex("UserId");

                    b.HasIndex("user_id");

                    b.ToTable("tb_experience", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Interest");

                    b.HasIndex("UserId");

                    b.HasIndex("user_id");

                    b.ToTable("tb_interest", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Language");

                    b.HasIndex("UserId");

                    b.HasIndex("user_id");

                    b.ToTable("tb_language", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("url");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Link");

                    b.HasIndex("UserId");

                    b.HasIndex("user_id");

                    b.ToTable("tb_link", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Skill");

                    b.HasIndex("UserId");

                    b.HasIndex("user_id");

                    b.ToTable("tb_skill", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.Property<int>("VacancyId")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Stage");

                    b.HasIndex("VacancyId");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_stage", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("admin");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext")
                        .HasColumnName("bio");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("PK_____User");

                    b.ToTable("tb_user", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CanApply")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_apply");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.Property<int>("WorkDays")
                        .HasColumnType("int")
                        .HasColumnName("work_days");

                    b.Property<DateTime>("WorkEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("work_end");

                    b.Property<DateTime>("WorkStart")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("work_start");

                    b.HasKey("Id")
                        .HasName("PK_____Vacancy");

                    b.ToTable("tb_vacancy", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.VacancyAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.Property<int?>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____VacancyAttribute");

                    b.HasIndex("VacancyId");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_vacancy_attribute", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Application", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "Candidate")
                        .WithMany()
                        .HasForeignKey("candidate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Models.Stage", "DismissalStage")
                        .WithMany()
                        .HasForeignKey("dismissal_stage_id");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("DismissalStage");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredEducation", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", null)
                        .WithMany("DesiredEducations")
                        .HasForeignKey("VacancyId");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredExperience", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", null)
                        .WithMany("DesiredExperiences")
                        .HasForeignKey("VacancyId");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredLanguage", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", null)
                        .WithMany("DesiredLanguages")
                        .HasForeignKey("VacancyId");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredSkill", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", null)
                        .WithMany("DesiredSkills")
                        .HasForeignKey("VacancyId");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.Education", b =>
                {
                    b.HasOne("Api.Domain.Models.User", null)
                        .WithMany("Educations")
                        .HasForeignKey("UserId");

                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Experience", b =>
                {
                    b.HasOne("Api.Domain.Models.User", null)
                        .WithMany("Experiences")
                        .HasForeignKey("UserId");

                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Interest", b =>
                {
                    b.HasOne("Api.Domain.Models.User", null)
                        .WithMany("Interests")
                        .HasForeignKey("UserId");

                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Language", b =>
                {
                    b.HasOne("Api.Domain.Models.User", null)
                        .WithMany("Languages")
                        .HasForeignKey("UserId");

                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Link", b =>
                {
                    b.HasOne("Api.Domain.Models.User", null)
                        .WithMany("Links")
                        .HasForeignKey("UserId");

                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Skill", b =>
                {
                    b.HasOne("Api.Domain.Models.User", null)
                        .WithMany("Skills")
                        .HasForeignKey("UserId");

                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Stage", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", null)
                        .WithMany("Stages")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.VacancyAttribute", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", null)
                        .WithMany("Attributes")
                        .HasForeignKey("VacancyId");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("vacancy_id");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.User", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Interests");

                    b.Navigation("Languages");

                    b.Navigation("Links");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Api.Domain.Models.Vacancy", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("DesiredEducations");

                    b.Navigation("DesiredExperiences");

                    b.Navigation("DesiredLanguages");

                    b.Navigation("DesiredSkills");

                    b.Navigation("Stages");
                });
#pragma warning restore 612, 618
        }
    }
}
