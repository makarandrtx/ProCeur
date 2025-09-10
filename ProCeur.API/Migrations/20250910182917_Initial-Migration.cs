using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProCeur.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedById = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Admin",
                table: "UserRoles",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "IsActive", "IsDefault", "LastModifiedById", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("b352141f-3603-44d5-b136-a39c9f9ee2e0"), new DateTime(2025, 7, 1, 19, 26, 13, 145, DateTimeKind.Unspecified).AddTicks(5952), false, true, new Guid("b352141f-3603-44d5-b136-a39c9f9ee2e0"), new DateTime(2025, 7, 1, 19, 26, 13, 145, DateTimeKind.Unspecified).AddTicks(5952), "Superadmin" },
                    { 2, new Guid("b352141f-3603-44d5-b136-a39c9f9ee2e0"), new DateTime(2025, 7, 1, 19, 26, 13, 145, DateTimeKind.Unspecified).AddTicks(5952), false, true, new Guid("b352141f-3603-44d5-b136-a39c9f9ee2e0"), new DateTime(2025, 7, 1, 19, 26, 13, 145, DateTimeKind.Unspecified).AddTicks(5952), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Admin");
        }
    }
}
