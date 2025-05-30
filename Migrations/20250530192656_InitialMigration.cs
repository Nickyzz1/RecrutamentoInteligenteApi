using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    bio = table.Column<string>(type: "longtext", nullable: true),
                    admin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____User", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_vacancy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    work_days = table.Column<int>(type: "int", nullable: false),
                    work_start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    work_end = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    can_apply = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Vacancy", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    institution = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    course = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_education_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_education_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    company = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    role = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    location = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_experience_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_experience_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_interest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Interest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_interest_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_interest_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_language_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_language_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_link_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_link_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_skill_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_skill_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_desired_education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    required = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____DesiredEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_desired_education_tb_vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_desired_education_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_desired_experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    time = table.Column<int>(type: "int", nullable: false),
                    required = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____DesiredExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_desired_experience_tb_vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_desired_experience_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_desired_language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    required = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____DesiredLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_desired_language_tb_vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_desired_language_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_desired_skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    required = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____DesiredSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_desired_skill_tb_vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_desired_skill_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_stage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Stage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_stage_tb_vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_stage_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_vacancy_attribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: true),
                    vacancy_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____VacancyAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_vacancy_attribute_tb_vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_vacancy_attribute_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    candidate_id = table.Column<int>(type: "int", nullable: false),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "longtext", nullable: false),
                    dismissal_stage_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_____Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_application_tb_stage_dismissal_stage_id",
                        column: x => x.dismissal_stage_id,
                        principalTable: "tb_stage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_application_tb_user_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_application_tb_vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "tb_vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_application_candidate_id",
                table: "tb_application",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_application_dismissal_stage_id",
                table: "tb_application",
                column: "dismissal_stage_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_application_vacancy_id",
                table: "tb_application",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_education_vacancy_id",
                table: "tb_desired_education",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_education_VacancyId",
                table: "tb_desired_education",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_experience_vacancy_id",
                table: "tb_desired_experience",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_experience_VacancyId",
                table: "tb_desired_experience",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_language_vacancy_id",
                table: "tb_desired_language",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_language_VacancyId",
                table: "tb_desired_language",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_skill_vacancy_id",
                table: "tb_desired_skill",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_skill_VacancyId",
                table: "tb_desired_skill",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_education_user_id",
                table: "tb_education",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_education_UserId",
                table: "tb_education",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_experience_user_id",
                table: "tb_experience",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_experience_UserId",
                table: "tb_experience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_interest_user_id",
                table: "tb_interest",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_interest_UserId",
                table: "tb_interest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_language_user_id",
                table: "tb_language",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_language_UserId",
                table: "tb_language",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_link_user_id",
                table: "tb_link",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_link_UserId",
                table: "tb_link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_skill_user_id",
                table: "tb_skill",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_skill_UserId",
                table: "tb_skill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stage_vacancy_id",
                table: "tb_stage",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stage_VacancyId",
                table: "tb_stage",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vacancy_attribute_vacancy_id",
                table: "tb_vacancy_attribute",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vacancy_attribute_VacancyId",
                table: "tb_vacancy_attribute",
                column: "VacancyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_application");

            migrationBuilder.DropTable(
                name: "tb_desired_education");

            migrationBuilder.DropTable(
                name: "tb_desired_experience");

            migrationBuilder.DropTable(
                name: "tb_desired_language");

            migrationBuilder.DropTable(
                name: "tb_desired_skill");

            migrationBuilder.DropTable(
                name: "tb_education");

            migrationBuilder.DropTable(
                name: "tb_experience");

            migrationBuilder.DropTable(
                name: "tb_interest");

            migrationBuilder.DropTable(
                name: "tb_language");

            migrationBuilder.DropTable(
                name: "tb_link");

            migrationBuilder.DropTable(
                name: "tb_skill");

            migrationBuilder.DropTable(
                name: "tb_vacancy_attribute");

            migrationBuilder.DropTable(
                name: "tb_stage");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_vacancy");
        }
    }
}
