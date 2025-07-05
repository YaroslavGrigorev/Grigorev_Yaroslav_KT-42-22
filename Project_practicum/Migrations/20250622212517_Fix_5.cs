using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project_practicum.Migrations
{
    /// <inheritdoc />
    public partial class Fix_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Teachers_HeadId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Disciplines_DisciplineId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Teachers_TeacherId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Degrees_DegreeId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loads",
                table: "Loads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LoadHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Disciplines");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Teachers",
                newName: "Position_Id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Teachers",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Teachers",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Teachers",
                newName: "Department_Id");

            migrationBuilder.RenameColumn(
                name: "DegreeId",
                table: "Teachers",
                newName: "Degree_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "Teacher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers",
                newName: "IX_Teachers_Position_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                newName: "idx_Teachers_fk_f_department_id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_DegreeId",
                table: "Teachers",
                newName: "idx_Teachers_fk_f_position_id");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Loads",
                newName: "Teacher_Id");

            migrationBuilder.RenameColumn(
                name: "DisciplineId",
                table: "Loads",
                newName: "Discipline_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Loads",
                newName: "Load_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_TeacherId",
                table: "Loads",
                newName: "idx_Loads_fk_f_teacher_id");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_DisciplineId",
                table: "Loads",
                newName: "idx_Loads_fk_f_discipline_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Disciplines",
                newName: "Discipline_Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Disciplines",
                newName: "Discipline_Id");

            migrationBuilder.RenameColumn(
                name: "HeadId",
                table: "Departments",
                newName: "Head_Id");

            migrationBuilder.RenameColumn(
                name: "FoundedDate",
                table: "Departments",
                newName: "Founded_Date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "Department_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_HeadId",
                table: "Departments",
                newName: "IX_Departments_Head_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Position_Id",
                table: "Teachers",
                type: "int4",
                nullable: false,
                comment: "Id занимаемой должности",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Teachers",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                comment: "Фамилия преподавателя",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Teachers",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                comment: "Имя преподавателя",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Department_Id",
                table: "Teachers",
                type: "int4",
                nullable: false,
                comment: "Id кафедры",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Degree_Id",
                table: "Teachers",
                type: "int4",
                nullable: false,
                comment: "Id ученой степени",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Teacher_Id",
                table: "Teachers",
                type: "integer",
                nullable: false,
                comment: "Id преподавателя",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "Loads",
                type: "int4",
                nullable: false,
                comment: "Количество часов нагрузки",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Teacher_Id",
                table: "Loads",
                type: "int4",
                nullable: false,
                comment: "Id преподавателя",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Discipline_Id",
                table: "Loads",
                type: "int4",
                nullable: false,
                comment: "Id дисциплины",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Load_Id",
                table: "Loads",
                type: "integer",
                nullable: false,
                comment: "Id нагрузки",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Discipline_Name",
                table: "Disciplines",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                comment: "Название дисциплины",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Discipline_Id",
                table: "Disciplines",
                type: "integer",
                nullable: false,
                comment: "Id дисциплины",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                comment: "Название факультета",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Head_Id",
                table: "Departments",
                type: "integer",
                nullable: true,
                comment: "Id зав. кафедры",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Founded_Date",
                table: "Departments",
                type: "timestamp",
                nullable: false,
                comment: "Дата основания факультета",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "Department_Id",
                table: "Departments",
                type: "integer",
                nullable: false,
                comment: "Id факультета",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pl_Teachers_teacher_id",
                table: "Teachers",
                column: "Teacher_Id");

            migrationBuilder.AddPrimaryKey(
                name: "pl_Loads_load_id",
                table: "Loads",
                column: "Load_Id");

            migrationBuilder.AddPrimaryKey(
                name: "pl_Disciplines_discipline_id",
                table: "Disciplines",
                column: "Discipline_Id");

            migrationBuilder.AddPrimaryKey(
                name: "pl_Departments_department_id",
                table: "Departments",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_f_degree_id",
                table: "Teachers",
                column: "Degree_Id");

            migrationBuilder.CreateIndex(
                name: "idx_Disciplines_name",
                table: "Disciplines",
                column: "Discipline_Name");

            migrationBuilder.CreateIndex(
                name: "idx_Departments_fk_f_head_id",
                table: "Departments",
                column: "Head_Id");

            migrationBuilder.AddForeignKey(
                name: "fk_f_head_id",
                table: "Departments",
                column: "Head_Id",
                principalTable: "Teachers",
                principalColumn: "Teacher_Id");

            migrationBuilder.AddForeignKey(
                name: "fk_f_discipline_id",
                table: "Loads",
                column: "Discipline_Id",
                principalTable: "Disciplines",
                principalColumn: "Discipline_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_f_teacher_id",
                table: "Loads",
                column: "Teacher_Id",
                principalTable: "Teachers",
                principalColumn: "Teacher_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_f_degree_id",
                table: "Teachers",
                column: "Degree_Id",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_f_department_id",
                table: "Teachers",
                column: "Department_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_f_position_id",
                table: "Teachers",
                column: "Position_Id",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_head_id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "fk_f_discipline_id",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "fk_f_teacher_id",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "fk_f_degree_id",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "fk_f_department_id",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "fk_f_position_id",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "pl_Teachers_teacher_id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "idx_Teachers_fk_f_degree_id",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "pl_Loads_load_id",
                table: "Loads");

            migrationBuilder.DropPrimaryKey(
                name: "pl_Disciplines_discipline_id",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "idx_Disciplines_name",
                table: "Disciplines");

            migrationBuilder.DropPrimaryKey(
                name: "pl_Departments_department_id",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "idx_Departments_fk_f_head_id",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Position_Id",
                table: "Teachers",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Teachers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Teachers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Department_Id",
                table: "Teachers",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Degree_Id",
                table: "Teachers",
                newName: "DegreeId");

            migrationBuilder.RenameColumn(
                name: "Teacher_Id",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_Position_Id",
                table: "Teachers",
                newName: "IX_Teachers_PositionId");

            migrationBuilder.RenameIndex(
                name: "idx_Teachers_fk_f_position_id",
                table: "Teachers",
                newName: "IX_Teachers_DegreeId");

            migrationBuilder.RenameIndex(
                name: "idx_Teachers_fk_f_department_id",
                table: "Teachers",
                newName: "IX_Teachers_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Teacher_Id",
                table: "Loads",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "Discipline_Id",
                table: "Loads",
                newName: "DisciplineId");

            migrationBuilder.RenameColumn(
                name: "Load_Id",
                table: "Loads",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "idx_Loads_fk_f_teacher_id",
                table: "Loads",
                newName: "IX_Loads_TeacherId");

            migrationBuilder.RenameIndex(
                name: "idx_Loads_fk_f_discipline_id",
                table: "Loads",
                newName: "IX_Loads_DisciplineId");

            migrationBuilder.RenameColumn(
                name: "Discipline_Name",
                table: "Disciplines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Discipline_Id",
                table: "Disciplines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Head_Id",
                table: "Departments",
                newName: "HeadId");

            migrationBuilder.RenameColumn(
                name: "Founded_Date",
                table: "Departments",
                newName: "FoundedDate");

            migrationBuilder.RenameColumn(
                name: "Department_Id",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_Head_Id",
                table: "Departments",
                newName: "IX_Departments_HeadId");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Id занимаемой должности");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldComment: "Фамилия преподавателя");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldComment: "Имя преподавателя");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Id кафедры");

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Id ученой степени");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id преподавателя")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Количество часов нагрузки");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Id преподавателя");

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Id дисциплины");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id нагрузки")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Disciplines",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Название дисциплины");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Disciplines",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id дисциплины")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "LoadHours",
                table: "Disciplines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Disciplines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldComment: "Название факультета");

            migrationBuilder.AlterColumn<int>(
                name: "HeadId",
                table: "Departments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "Id зав. кафедры");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FoundedDate",
                table: "Departments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldComment: "Дата основания факультета");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Departments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id факультета")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loads",
                table: "Loads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Teachers_HeadId",
                table: "Departments",
                column: "HeadId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Disciplines_DisciplineId",
                table: "Loads",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Teachers_TeacherId",
                table: "Loads",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Degrees_DegreeId",
                table: "Teachers",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
