﻿// <auto-generated />
using System;
using Api.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DaredeDbContext))]
    partial class DaredeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredEducation");

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

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredExperience");

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

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredLanguage");

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

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____DesiredSkill");

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

                    b.Property<DateTime?>("EndDate")
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

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Education");

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

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Experience");

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

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Interest");

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

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Language");

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

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Link");

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

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Skill");

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

                    b.Property<int>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____Stage");

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

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tb_user", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Admin = true,
                            Email = "eduardo@email.com",
                            IsActive = true,
                            Name = "Eduardo",
                            Password = "AQAAAAIAAYagAAAAELBAgPwfxALpFLND1JAS4Kfey4PgwPQI/nPx64bVUob23L3gdn1HLzO7GWa1SKWFTw=="
                        },
                        new
                        {
                            Id = 2,
                            Admin = true,
                            Email = "nicolle@email.com",
                            IsActive = true,
                            Name = "Nicolle",
                            Password = "AQAAAAIAAYagAAAAEAcj/wdXqe4TmIFgb9+2De5fnyEyGDSjSBqd9bnVwKc6avxMZnUU4rYjvl6VNr9+Ew=="
                        },
                        new
                        {
                            Id = 3,
                            Admin = true,
                            Email = "adrian@email.com",
                            IsActive = true,
                            Name = "Adrian",
                            Password = "AQAAAAIAAYagAAAAEBpsoBsJl3nwjzdulnKIVqPp4bssufjWxVCtPYwfR9Rt3MLyIbwaC547pJca/oCrWw=="
                        },
                        new
                        {
                            Id = 4,
                            Address = "Rua Mariano Procópio, 37",
                            Admin = false,
                            Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam aliquam tincidunt accumsan. Curabitur faucibus lorem pharetra dapibus bibendum.",
                            Email = "alonso@email.com",
                            IsActive = true,
                            Name = "Chico Alonso",
                            Password = "AQAAAAIAAYagAAAAEFP4sSIucdUSfO/ehFND1e/UyyZc6/KO1C83LsWTQdqK8zmbaOBWqc5C2Qybq5onwg==",
                            Phone = "41999999991"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Praça da Ceilândia",
                            Admin = false,
                            Bio = "Traficante/Carpinteiro",
                            Email = "joao@email.com",
                            IsActive = true,
                            Name = "João de Santo Cristo",
                            Password = "AQAAAAIAAYagAAAAEEU7KTOCjeBIRlMZDIb5EAcB+zp4AzdE2wkAM+SCN593jjpb6lE7Hk4VyVkkuG6xfw==",
                            Phone = "41999999992"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Rua Juscelino Kubitschek",
                            Admin = false,
                            Bio = "Padre",
                            Email = "domingos@email.com",
                            IsActive = true,
                            Name = "Domingos",
                            Password = "AQAAAAIAAYagAAAAEKrduVm2aIyEWzjGP6ZOdGv4sENjt3Ww81Y9F43JOOnGsE1MSx/GtWcplwiWjNN3YQ==",
                            Phone = "41999999993"
                        });
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

                    b.Property<int?>("vacancy_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_____VacancyAttribute");

                    b.HasIndex("vacancy_id");

                    b.ToTable("tb_vacancy_attribute", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Models.Application", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "Candidate")
                        .WithMany("Applications")
                        .HasForeignKey("candidate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Models.Stage", "DismissalStage")
                        .WithMany()
                        .HasForeignKey("dismissal_stage_id");

                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("Applications")
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("DismissalStage");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredEducation", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("DesiredEducations")
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredExperience", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("DesiredExperiences")
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredLanguage", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("DesiredLanguages")
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.DesiredSkill", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("DesiredSkills")
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.Education", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany("Educations")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Experience", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany("Experiences")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Interest", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany("Interests")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Language", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany("Languages")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Link", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany("Links")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Skill", b =>
                {
                    b.HasOne("Api.Domain.Models.User", "User")
                        .WithMany("Skills")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Models.Stage", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("Stages")
                        .HasForeignKey("vacancy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.VacancyAttribute", b =>
                {
                    b.HasOne("Api.Domain.Models.Vacancy", "Vacancy")
                        .WithMany("Attributes")
                        .HasForeignKey("vacancy_id");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Api.Domain.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Interests");

                    b.Navigation("Languages");

                    b.Navigation("Links");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Api.Domain.Models.Vacancy", b =>
                {
                    b.Navigation("Applications");

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
