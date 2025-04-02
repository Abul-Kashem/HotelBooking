using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFieldNameInVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Villas",
                newName: "Updated_Date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Villas",
                newName: "Created_Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_Date",
                table: "Villas",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Created_Date",
                table: "Villas",
                newName: "CreateDate");
        }
    }
}
