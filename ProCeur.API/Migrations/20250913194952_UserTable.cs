using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProCeur.API.Migrations
{
    /// <inheritdoc />
    public partial class UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserRoleId = table.Column<int>(type: "integer", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    TokenExpiryTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "Admin",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Admin",
                table: "Users",
                columns: new[] { "Id", "Email", "Firstname", "IsAdmin", "LastLoginAt", "Lastname", "Password", "RefreshToken", "TokenExpiryTime", "UserRoleId" },
                values: new object[] { new Guid("28e1cd24-4cbd-4628-bc3b-2af0719efca3"), "superadmin@email.com", "Superadmin", true, null, "Superadmin", "ZdI02Zov/Puh7ZZyBDPYkg==", null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                schema: "Admin",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "Admin");
        }
    }
}
