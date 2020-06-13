using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class CreateDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointment_TypeMedicalAppointment_TypeMedicalAppointmentId",
                table: "MedicalAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointment_Users_Username",
                table: "MedicalAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rol_RolId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeMedicalAppointment",
                table: "TypeMedicalAppointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalAppointment",
                table: "MedicalAppointment");

            migrationBuilder.RenameTable(
                name: "TypeMedicalAppointment",
                newName: "TypeMedicalAppointments");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Rols");

            migrationBuilder.RenameTable(
                name: "MedicalAppointment",
                newName: "MedicalAppointments");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalAppointment_Username",
                table: "MedicalAppointments",
                newName: "IX_MedicalAppointments_Username");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalAppointment_TypeMedicalAppointmentId",
                table: "MedicalAppointments",
                newName: "IX_MedicalAppointments_TypeMedicalAppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeMedicalAppointments",
                table: "TypeMedicalAppointments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rols",
                table: "Rols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalAppointments",
                table: "MedicalAppointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_TypeMedicalAppointments_TypeMedicalAppointmentId",
                table: "MedicalAppointments",
                column: "TypeMedicalAppointmentId",
                principalTable: "TypeMedicalAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Users_Username",
                table: "MedicalAppointments",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rols_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_TypeMedicalAppointments_TypeMedicalAppointmentId",
                table: "MedicalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Users_Username",
                table: "MedicalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rols_RolId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeMedicalAppointments",
                table: "TypeMedicalAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rols",
                table: "Rols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalAppointments",
                table: "MedicalAppointments");

            migrationBuilder.RenameTable(
                name: "TypeMedicalAppointments",
                newName: "TypeMedicalAppointment");

            migrationBuilder.RenameTable(
                name: "Rols",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "MedicalAppointments",
                newName: "MedicalAppointment");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalAppointments_Username",
                table: "MedicalAppointment",
                newName: "IX_MedicalAppointment_Username");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalAppointments_TypeMedicalAppointmentId",
                table: "MedicalAppointment",
                newName: "IX_MedicalAppointment_TypeMedicalAppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeMedicalAppointment",
                table: "TypeMedicalAppointment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalAppointment",
                table: "MedicalAppointment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointment_TypeMedicalAppointment_TypeMedicalAppointmentId",
                table: "MedicalAppointment",
                column: "TypeMedicalAppointmentId",
                principalTable: "TypeMedicalAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointment_Users_Username",
                table: "MedicalAppointment",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rol_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
