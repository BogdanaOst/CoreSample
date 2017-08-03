using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BinaryCoreSample.Migrations
{
    public partial class fixedMissprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumverOfHomemates",
                table: "Houses",
                newName: "NumberOfHomemates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfHomemates",
                table: "Houses",
                newName: "NumverOfHomemates");
        }
    }
}
