using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XStore.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToUserMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActived",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActived",
                table: "Users");
        }
    }
}
