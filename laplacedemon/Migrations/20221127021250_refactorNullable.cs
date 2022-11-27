using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laplacedemon.Migrations
{
    public partial class refactorNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "varchar", nullable: false),
                    TrustedAsAnalist = table.Column<int>(type: "int", nullable: false),
                    TrustedAsExpertAnalist = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(800)", maxLength: 800, nullable: false),
                    Price = table.Column<double>(type: "Float", nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coin_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProfileView",
                columns: table => new
                {
                    UserVisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserVisitorId1 = table.Column<int>(type: "int", nullable: false),
                    ViewDate = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileView", x => x.UserVisitorId);
                    table.ForeignKey(
                        name: "FK_UserProfileView_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    IsBloqued = table.Column<bool>(type: "bit", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true),
                    UserProfileViewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_UserProfileView_UserProfileViewId",
                        column: x => x.UserProfileViewId,
                        principalTable: "UserProfileView",
                        principalColumn: "UserVisitorId");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(2000)", maxLength: 2000, nullable: false),
                    SuggestedPrice = table.Column<double>(type: "FLOAT", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false),
                    isActive = table.Column<bool>(type: "Bit", nullable: false),
                    Bulls = table.Column<int>(type: "int", nullable: false),
                    Bears = table.Column<int>(type: "int", nullable: false),
                    CoinId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Coin",
                        column: x => x.CoinId,
                        principalTable: "Coin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR(2000)", maxLength: 2000, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComment_Post",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostComment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coin_UserProfileId",
                table: "Coin",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CoinId",
                table: "Post",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserProfileId",
                table: "Post",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostId",
                table: "PostComment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_UserId",
                table: "PostComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInfoId",
                table: "User",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserProfileId",
                table: "User",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserProfileViewId",
                table: "User",
                column: "UserProfileViewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileView_UserProfileId",
                table: "UserProfileView",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Coin");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserProfileView");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
