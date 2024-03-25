using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RZA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingHotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Loyalty_Cost",
                table: "Bookings",
                newName: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Bookings",
                newName: "Loyalty_Cost");
        }
    }
}
