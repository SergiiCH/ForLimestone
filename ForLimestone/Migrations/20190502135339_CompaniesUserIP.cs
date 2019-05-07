using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForLimestone.Migrations
{
    public partial class CompaniesUserIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyUsersIP",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Company = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsersIP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IPaddresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CompanyUsers_IP_addressID = table.Column<Guid>(nullable: false),
                    IPaddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPaddresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IPaddresses_CompanyUsersIP_CompanyUsers_IP_addressID",
                        column: x => x.CompanyUsers_IP_addressID,
                        principalTable: "CompanyUsersIP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPaddresses_CompanyUsers_IP_addressID",
                table: "IPaddresses",
                column: "CompanyUsers_IP_addressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPaddresses");

            migrationBuilder.DropTable(
                name: "CompanyUsersIP");
        }
    }
}
