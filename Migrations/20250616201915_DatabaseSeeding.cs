using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "tb_education",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "Id", "address", "admin", "bio", "email", "is_active", "name", "password", "phone" },
                values: new object[,]
                {
                    { 1, null, true, null, "eduardo@email.com", true, "Eduardo", "AQAAAAIAAYagAAAAELBAgPwfxALpFLND1JAS4Kfey4PgwPQI/nPx64bVUob23L3gdn1HLzO7GWa1SKWFTw==", null },
                    { 2, null, true, null, "nicolle@email.com", true, "Nicolle", "AQAAAAIAAYagAAAAEAcj/wdXqe4TmIFgb9+2De5fnyEyGDSjSBqd9bnVwKc6avxMZnUU4rYjvl6VNr9+Ew==", null },
                    { 3, null, true, null, "adrian@email.com", true, "Adrian", "AQAAAAIAAYagAAAAEBpsoBsJl3nwjzdulnKIVqPp4bssufjWxVCtPYwfR9Rt3MLyIbwaC547pJca/oCrWw==", null },
                    { 4, "Rua Mariano Procópio, 37", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam aliquam tincidunt accumsan. Curabitur faucibus lorem pharetra dapibus bibendum.", "alonso@email.com", true, "Chico Alonso", "AQAAAAIAAYagAAAAEFP4sSIucdUSfO/ehFND1e/UyyZc6/KO1C83LsWTQdqK8zmbaOBWqc5C2Qybq5onwg==", "41999999991" },
                    { 5, "Praça da Ceilândia", false, "Traficante/Carpinteiro", "joao@email.com", true, "João de Santo Cristo", "AQAAAAIAAYagAAAAEEU7KTOCjeBIRlMZDIb5EAcB+zp4AzdE2wkAM+SCN593jjpb6lE7Hk4VyVkkuG6xfw==", "41999999992" },
                    { 6, "Rua Juscelino Kubitschek", false, "Padre", "domingos@email.com", true, "Domingos", "AQAAAAIAAYagAAAAEKrduVm2aIyEWzjGP6ZOdGv4sENjt3Ww81Y9F43JOOnGsE1MSx/GtWcplwiWjNN3YQ==", "41999999993" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "tb_education",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
