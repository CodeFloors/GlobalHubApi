﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalHub.Migrations
{
    public partial class initialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    PkapplicationsCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imageurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AllowsDownloads = table.Column<bool>(type: "bit", nullable: false),
                    AllowsInventoryUpdates = table.Column<bool>(type: "bit", nullable: false),
                    AllowsLabelGeneration = table.Column<bool>(type: "bit", nullable: false),
                    AllowsInvoicing = table.Column<bool>(type: "bit", nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.PkapplicationsCode);
                });

            migrationBuilder.CreateTable(
                name: "Counteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PKCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userfirstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userlastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usercompanyname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Useraddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Useraddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Useraddress3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usercity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usercounty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userstate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usercountrycode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userpostcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usertelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Useremail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationParameterNames",
                columns: table => new
                {
                    PkapplicationParameterCode = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkApplicationCode = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplaySequence = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationParameterNames", x => x.PkapplicationParameterCode);
                    table.ForeignKey(
                        name: "FK_ApplicationParameterNames_Applications_FkApplicationCode",
                        column: x => x.FkApplicationCode,
                        principalTable: "Applications",
                        principalColumn: "PkapplicationsCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationsAccounts",
                columns: table => new
                {
                    PkAccountCode = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkuserId = table.Column<long>(type: "bigint", nullable: false),
                    FkApplicationCode = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsAccounts", x => x.PkAccountCode);
                    table.ForeignKey(
                        name: "FK_ApplicationsAccounts_Applications_FkApplicationCode",
                        column: x => x.FkApplicationCode,
                        principalTable: "Applications",
                        principalColumn: "PkapplicationsCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationsAccounts_Users_FkuserId",
                        column: x => x.FkuserId,
                        principalTable: "Users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationParameters",
                columns: table => new
                {
                    PkapplicationParameterCode = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkAccountCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationParameters", x => x.PkapplicationParameterCode);
                    table.ForeignKey(
                        name: "FK_ApplicationParameters_ApplicationsAccounts_FkAccountCode",
                        column: x => x.FkAccountCode,
                        principalTable: "ApplicationsAccounts",
                        principalColumn: "PkAccountCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationParameterNames_FkApplicationCode",
                table: "ApplicationParameterNames",
                column: "FkApplicationCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationParameters_FkAccountCode",
                table: "ApplicationParameters",
                column: "FkAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsAccounts_FkApplicationCode",
                table: "ApplicationsAccounts",
                column: "FkApplicationCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsAccounts_FkuserId",
                table: "ApplicationsAccounts",
                column: "FkuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationParameterNames");

            migrationBuilder.DropTable(
                name: "ApplicationParameters");

            migrationBuilder.DropTable(
                name: "Counteries");

            migrationBuilder.DropTable(
                name: "ApplicationsAccounts");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
