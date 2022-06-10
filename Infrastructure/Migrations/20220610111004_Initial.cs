using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountOfUnits = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsRegistrationOpened = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Challenges_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeUser",
                columns: table => new
                {
                    ChallengesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeUser", x => new { x.ChallengesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ChallengeUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeUser_Challenges_ChallengesId",
                        column: x => x.ChallengesId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountOfUnitsDone = table.Column<int>(type: "int", nullable: false),
                    PercentOfDone = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTasks_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Frequencies",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Per Day" },
                    { 2, "Per Week" },
                    { 3, "Per Month" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Beginner" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ShortType", "Type" },
                values: new object[,]
                {
                    { 1, "times", "times" },
                    { 2, "min", "minutes" },
                    { 3, "m", "meters" },
                    { 4, "km", "kilometers" },
                    { 5, "ml", "milliliters" },
                    { 6, "pages", "pages" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StatusId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "39d1363e-822e-493d-815e-6c2cc82c66df", 0, "a1261fc3-d767-434d-9d46-496d3025e448", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEJ1IRkBE3YmWZBMr8porMft+iutU1wbqPQmNuvjrI1YISmPA8WY+o2FO/3zvY1U+Bw==", null, false, "bc5730a6-ac37-49b1-a1ca-f0c8645643b0", 1, false, "a_korolchuk" },
                    { "cc210271-921d-48f8-b759-e442547288e1", 0, "1de4721c-be9a-4057-b2c5-2968ee742f8e", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEMJ5pyTBEVpONKpnJHn/VKPGLq2EuWCoOG6EmPkZN0L7n0FB3cmatIegPE2LAbvE9g==", null, false, "1d8997e4-fe1e-453c-9aac-2f64da4bd5eb", 1, false, "ton4ik" },
                    { "2c3542d5-088a-4aed-b8d7-e785ea9ede84", 0, "ac0a6301-5c18-49ea-a994-eed56a70d5ed", "User", "Ramiro.Stehr@hotmail.com", false, false, null, "RAMIRO.STEHR@HOTMAIL.COM", "RAMIRO80", "AQAAAAEAACcQAAAAEJ23O4cRbvEFnRqd5kIttQaFEyi6xCF/sCOa4/AAOe/+xsIc8dPmq6fxGVpayi2IXg==", null, false, "1a91f0e1-ce62-4145-88ba-5c26093a50df", 1, false, "Ramiro80" },
                    { "55beb5b9-a4d7-447a-9992-6199b7a4b5a5", 0, "d3b6cd54-9c9e-41b1-8270-08a2d3f33900", "User", "Angelo36@hotmail.com", false, false, null, "ANGELO36@HOTMAIL.COM", "ANGELO_SATTERFIELD66", "AQAAAAEAACcQAAAAEJ2cq6r+5yvv/DV0JaP/5MCDi0KpC0jJK9tKx0B3UxdbyjgbdzQwxrwdF0hGyjGSbA==", null, false, "b2b1d776-7966-4fd4-aad8-ca0c12917d5f", 1, false, "Angelo_Satterfield66" },
                    { "ff5143a6-8d50-4141-a99a-a465a523e435", 0, "61b8d12e-e0d2-4624-a648-2a48cf0e0c3a", "User", "Marion79@yahoo.com", false, false, null, "MARION79@YAHOO.COM", "MARION_MOEN", "AQAAAAEAACcQAAAAEOzfOxDnXCEbx77Qb6erElUlMwfAFYFO9efkbQubw2ZM/xZltQoVj086MzgBexaE6g==", null, false, "030bea92-4330-4ebc-9263-fe3eea6ea49c", 1, false, "Marion_Moen" },
                    { "95c04a47-51b9-4669-840f-abea3942cb8a", 0, "407b6476-90db-444d-b75b-2a1c8646d9f7", "User", "Gwen35@hotmail.com", false, false, null, "GWEN35@HOTMAIL.COM", "GWEN.LANGOSH", "AQAAAAEAACcQAAAAENwn0OlJaEZkY93Zt+gzpovxr7xnGeNSKEyjEVz31rHrmzqUz+y4/j3rOItX/os7vg==", null, false, "f8965f65-18fd-4be6-9297-2df23ebbecdb", 1, false, "Gwen.Langosh" }
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "AuthorId", "CountOfUnits", "EndDate", "FrequencyId", "IsRegistrationOpened", "StartDate", "Title", "UnitId" },
                values: new object[] { 1, "2c3542d5-088a-4aed-b8d7-e785ea9ede84", 1500, new DateTimeOffset(new DateTime(2022, 7, 2, 14, 10, 3, 667, DateTimeKind.Unspecified).AddTicks(8568), new TimeSpan(0, 3, 0, 0, 0)), 1, true, new DateTimeOffset(new DateTime(2022, 6, 11, 14, 10, 3, 667, DateTimeKind.Unspecified).AddTicks(7002), new TimeSpan(0, 3, 0, 0, 0)), "Drink water", 5 });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "ChallengeId", "CountOfUnitsDone", "Date", "PercentOfDone" },
                values: new object[,]
                {
                    { 1, 1, 750, new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Local), 50 },
                    { 19, 1, 0, new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 18, 1, 0, new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 17, 1, 0, new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 16, 1, 0, new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 15, 1, 0, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 14, 1, 0, new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 13, 1, 0, new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 12, 1, 0, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 20, 1, 0, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 11, 1, 0, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 9, 1, 0, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 8, 1, 0, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 7, 1, 0, new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 6, 1, 0, new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 5, 1, 0, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 4, 1, 0, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 3, 1, 0, new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 2, 1, 0, new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 10, 1, 0, new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 21, 1, 0, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_AuthorId",
                table: "Challenges",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_FrequencyId",
                table: "Challenges",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_UnitId",
                table: "Challenges",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeUser_UsersId",
                table: "ChallengeUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_ChallengeId",
                table: "DailyTasks",
                column: "ChallengeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChallengeUser");

            migrationBuilder.DropTable(
                name: "DailyTasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
