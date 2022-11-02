using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class CreatePet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_PetOwners_PetOwnerid",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwnerid",
                table: "Pets",
                newName: "petOwnerid");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_PetOwnerid",
                table: "Pets",
                newName: "IX_Pets_petOwnerid");

            migrationBuilder.AlterColumn<int>(
                name: "petOwnerid",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "breed",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "checkedInAt",
                table: "Pets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "color",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "breed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "checkedInAt",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "Pet",
                newName: "PetOwnerid");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pet",
                newName: "IX_Pet_PetOwnerid");

            migrationBuilder.AlterColumn<int>(
                name: "PetOwnerid",
                table: "Pet",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetOwners_PetOwnerid",
                table: "Pet",
                column: "PetOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
