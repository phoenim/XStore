using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XStore.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class PriceForCartMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceForCount",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceForOne",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PriceForCount",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "PriceForOne",
                table: "CartItems");
        }
    }
}
