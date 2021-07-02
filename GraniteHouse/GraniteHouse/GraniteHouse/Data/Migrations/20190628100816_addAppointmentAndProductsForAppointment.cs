using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraniteHouse.Data.Migrations
{
  public partial class addAppointmentAndProductsForAppointment : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Appointments",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            AppointmentDate = table.Column<DateTime>(nullable: false),
            CustomerName = table.Column<string>(nullable: true),
            CustomerPhoneNumber = table.Column<string>(nullable: true),
            CustomerEmail = table.Column<string>(nullable: true),
            isConfirmed = table.Column<bool>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Appointments", x => x.ID);
          });

      migrationBuilder.CreateTable(
          name: "ProductsSelectedForAppointments",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            AppointmentID = table.Column<int>(nullable: false),
            ProductID = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ProductsSelectedForAppointments", x => x.ID);
            table.ForeignKey(
                      name: "FK_ProductsSelectedForAppointments_Appointments_AppointmentID",
                      column: x => x.AppointmentID,
                      principalTable: "Appointments",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ProductsSelectedForAppointments_Products_ProductID",
                      column: x => x.ProductID,
                      principalTable: "Products",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_ProductsSelectedForAppointments_AppointmentID",
          table: "ProductsSelectedForAppointments",
          column: "AppointmentID");

      migrationBuilder.CreateIndex(
          name: "IX_ProductsSelectedForAppointments_ProductID",
          table: "ProductsSelectedForAppointments",
          column: "ProductID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "ProductsSelectedForAppointments");

      migrationBuilder.DropTable(
          name: "Appointments");
    }
  }
}
