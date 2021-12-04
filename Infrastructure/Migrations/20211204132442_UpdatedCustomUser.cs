using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdatedCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationId",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reserve_UserId",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_NotificationId",
                table: "BaseEntity",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reserve_UserId",
                table: "BaseEntity",
                column: "Reserve_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_Reserve_UserId",
                table: "BaseEntity",
                column: "Reserve_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_UserId",
                table: "BaseEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_NotificationId",
                table: "BaseEntity",
                column: "NotificationId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_Reserve_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_NotificationId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_NotificationId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Reserve_UserId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Reserve_UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
