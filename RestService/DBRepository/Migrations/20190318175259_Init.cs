﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''");

            migrationBuilder.CreateTable(
                "Positions",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    WorkPeriodStartDate = table.Column<DateTime>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        "FK_Users_Positions_PositionId",
                        x => x.PositionId,
                        "Positions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Positions",
                new[] { "Id", "Name" },
                new object[,]
                {
                    { new Guid("bb28f13b-8ee5-4c59-a927-e269bded4f02"), "Tester" },
                    { new Guid("e49ac4a8-c56d-4446-85c1-cd771526859c"), "AQA" },
                    { new Guid("e2bba64d-e100-42e3-a506-3c08f3f6181d"), "CTO" },
                    { new Guid("6dbfa58c-1c35-4110-be3d-68fcf2fa8fdd"), "CEO" },
                    { new Guid("0b365f91-6b7a-4469-9894-308a20861622"), "CBO" },
                    { new Guid("036fc1ef-ca78-4f1e-9be9-b9dfaadc8b9e"), "Java Developer" },
                    { new Guid("7166816c-80d8-4b9b-b76c-aefda0ebb2b1"), "C# Developer" },
                    { new Guid("7717bf67-12a5-42fd-aa50-facd07bd6449"), "Python Developer" }
                });

            migrationBuilder.CreateIndex(
                "IX_Users_PositionId",
                "Users",
                "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Positions");
        }
    }
}
