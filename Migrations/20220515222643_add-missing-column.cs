using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalHub.Migrations
{
    public partial class addmissingcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "HelpText",
                table: "ApplicationParameterNames",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "HelpUrl",
                table: "ApplicationParameterNames",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IncludeInDispatchAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IncludeInInventoryAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IncludeInInvoiceAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IncludeInLabelAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IncludeInOrdersAPI",
                table: "ApplicationParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<int>(
                name: "PageTab",
                table: "ApplicationParameterNames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "HelpText",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "HelpUrl",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "IncludeInDispatchAPI",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "IncludeInInventoryAPI",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "IncludeInInvoiceAPI",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "IncludeInLabelAPI",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "IncludeInOrdersAPI",
                table: "ApplicationParameterNames");

            _ = migrationBuilder.DropColumn(
                name: "PageTab",
                table: "ApplicationParameterNames");
        }
    }
}
