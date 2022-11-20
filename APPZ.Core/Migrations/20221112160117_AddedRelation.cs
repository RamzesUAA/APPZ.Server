using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPZ.Core.Migrations
{
    public partial class AddedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganisationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlackHook = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationDetails_Users_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationNotifications_OrgId",
                table: "OrganisationNotifications",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FromOrgId",
                table: "Notifications",
                column: "FromOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ToUserId",
                table: "Notifications",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationDetails_OrganisationId",
                table: "OrganisationDetails",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_FromOrgId",
                table: "Notifications",
                column: "FromOrgId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_ToUserId",
                table: "Notifications",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationNotifications_Users_OrgId",
                table: "OrganisationNotifications",
                column: "OrgId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_FromOrgId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_ToUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationNotifications_Users_OrgId",
                table: "OrganisationNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "OrganisationDetails");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UserId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_OrganisationNotifications_OrgId",
                table: "OrganisationNotifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_FromOrgId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ToUserId",
                table: "Notifications");
        }
    }
}
