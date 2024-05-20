using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reposatry.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNationaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "healthInsuranceNumber",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NationalID",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "healthInsuranceNumber",
                table: "Patients",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NationalID",
                table: "Patients",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "healthInsuranceId",
                table: "Doctors",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NationalID",
                table: "Doctors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "healthInsuranceNumber",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NationalID",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "healthInsuranceNumber",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NationalID",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "healthInsuranceId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NationalID",
                table: "Doctors",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
