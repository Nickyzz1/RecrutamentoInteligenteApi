using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_desired_education_tb_vacancy_VacancyId",
                table: "tb_desired_education");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_desired_experience_tb_vacancy_VacancyId",
                table: "tb_desired_experience");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_desired_language_tb_vacancy_VacancyId",
                table: "tb_desired_language");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_desired_skill_tb_vacancy_VacancyId",
                table: "tb_desired_skill");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_education_tb_user_UserId",
                table: "tb_education");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_experience_tb_user_UserId",
                table: "tb_experience");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_interest_tb_user_UserId",
                table: "tb_interest");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_language_tb_user_UserId",
                table: "tb_language");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_link_tb_user_UserId",
                table: "tb_link");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_skill_tb_user_UserId",
                table: "tb_skill");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_stage_tb_vacancy_VacancyId",
                table: "tb_stage");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_vacancy_attribute_tb_vacancy_VacancyId",
                table: "tb_vacancy_attribute");

            migrationBuilder.DropIndex(
                name: "IX_tb_vacancy_attribute_VacancyId",
                table: "tb_vacancy_attribute");

            migrationBuilder.DropIndex(
                name: "IX_tb_stage_VacancyId",
                table: "tb_stage");

            migrationBuilder.DropIndex(
                name: "IX_tb_skill_UserId",
                table: "tb_skill");

            migrationBuilder.DropIndex(
                name: "IX_tb_link_UserId",
                table: "tb_link");

            migrationBuilder.DropIndex(
                name: "IX_tb_language_UserId",
                table: "tb_language");

            migrationBuilder.DropIndex(
                name: "IX_tb_interest_UserId",
                table: "tb_interest");

            migrationBuilder.DropIndex(
                name: "IX_tb_experience_UserId",
                table: "tb_experience");

            migrationBuilder.DropIndex(
                name: "IX_tb_education_UserId",
                table: "tb_education");

            migrationBuilder.DropIndex(
                name: "IX_tb_desired_skill_VacancyId",
                table: "tb_desired_skill");

            migrationBuilder.DropIndex(
                name: "IX_tb_desired_language_VacancyId",
                table: "tb_desired_language");

            migrationBuilder.DropIndex(
                name: "IX_tb_desired_experience_VacancyId",
                table: "tb_desired_experience");

            migrationBuilder.DropIndex(
                name: "IX_tb_desired_education_VacancyId",
                table: "tb_desired_education");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "tb_vacancy_attribute");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "tb_stage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_skill");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_link");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_language");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_interest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_experience");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_education");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "tb_desired_skill");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "tb_desired_language");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "tb_desired_experience");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "tb_desired_education");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_email",
                table: "tb_user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_user_email",
                table: "tb_user");

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "tb_vacancy_attribute",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "tb_stage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_skill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_link",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_language",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_interest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_experience",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_education",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "tb_desired_skill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "tb_desired_language",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "tb_desired_experience",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "tb_desired_education",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_vacancy_attribute_VacancyId",
                table: "tb_vacancy_attribute",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stage_VacancyId",
                table: "tb_stage",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_skill_UserId",
                table: "tb_skill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_link_UserId",
                table: "tb_link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_language_UserId",
                table: "tb_language",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_interest_UserId",
                table: "tb_interest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_experience_UserId",
                table: "tb_experience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_education_UserId",
                table: "tb_education",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_skill_VacancyId",
                table: "tb_desired_skill",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_language_VacancyId",
                table: "tb_desired_language",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_experience_VacancyId",
                table: "tb_desired_experience",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_desired_education_VacancyId",
                table: "tb_desired_education",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_desired_education_tb_vacancy_VacancyId",
                table: "tb_desired_education",
                column: "VacancyId",
                principalTable: "tb_vacancy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_desired_experience_tb_vacancy_VacancyId",
                table: "tb_desired_experience",
                column: "VacancyId",
                principalTable: "tb_vacancy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_desired_language_tb_vacancy_VacancyId",
                table: "tb_desired_language",
                column: "VacancyId",
                principalTable: "tb_vacancy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_desired_skill_tb_vacancy_VacancyId",
                table: "tb_desired_skill",
                column: "VacancyId",
                principalTable: "tb_vacancy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_education_tb_user_UserId",
                table: "tb_education",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_experience_tb_user_UserId",
                table: "tb_experience",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_interest_tb_user_UserId",
                table: "tb_interest",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_language_tb_user_UserId",
                table: "tb_language",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_link_tb_user_UserId",
                table: "tb_link",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_skill_tb_user_UserId",
                table: "tb_skill",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_stage_tb_vacancy_VacancyId",
                table: "tb_stage",
                column: "VacancyId",
                principalTable: "tb_vacancy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vacancy_attribute_tb_vacancy_VacancyId",
                table: "tb_vacancy_attribute",
                column: "VacancyId",
                principalTable: "tb_vacancy",
                principalColumn: "Id");
        }
    }
}
