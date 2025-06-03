using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProj.Migrations
{
    /// <inheritdoc />
    public partial class FixRegistrationDateAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistartionDate",
                table: "Users",
                newName: "RegistrationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Users",
                newName: "RegistartionDate");
        }
    }
}
