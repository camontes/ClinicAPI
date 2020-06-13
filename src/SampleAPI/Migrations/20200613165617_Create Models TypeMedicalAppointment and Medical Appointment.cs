using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class CreateModelsTypeMedicalAppointmentandMedicalAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeMedicalAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMedicalAppointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    TypeMedicalAppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAppointment_TypeMedicalAppointment_TypeMedicalAppointmentId",
                        column: x => x.TypeMedicalAppointmentId,
                        principalTable: "TypeMedicalAppointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalAppointment_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TypeMedicalAppointment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Medicina General" },
                    { 2, "Odontología" },
                    { 3, "Pediatría" },
                    { 4, "Neurología" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_TypeMedicalAppointmentId",
                table: "MedicalAppointment",
                column: "TypeMedicalAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_Username",
                table: "MedicalAppointment",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalAppointment");

            migrationBuilder.DropTable(
                name: "TypeMedicalAppointment");
        }
    }
}
