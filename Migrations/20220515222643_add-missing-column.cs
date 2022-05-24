using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalHub.Migrations
{
    public partial class addmissingcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HelpText",
                table: "ApplicationParameterNames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HelpUrl",
                table: "ApplicationParameterNames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInDispatchAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInInventoryAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInInvoiceAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInLabelAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInOrdersAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PageTab",
                table: "ApplicationParameterNames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpText",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "HelpUrl",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "IncludeInDispatchAPI",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "IncludeInInventoryAPI",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "IncludeInInvoiceAPI",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "IncludeInLabelAPI",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "IncludeInOrdersAPI",
                table: "ApplicationParameterNames");

            migrationBuilder.DropColumn(
                name: "PageTab",
                table: "ApplicationParameterNames");
        }
    }
}
