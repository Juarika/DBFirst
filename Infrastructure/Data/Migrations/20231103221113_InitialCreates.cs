using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "idDriver",
                table: "teamdriver");

            migrationBuilder.DropForeignKey(
                name: "idTeam",
                table: "teamdriver");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "teamdriver");

            migrationBuilder.RenameTable(
                name: "teamdriver",
                newName: "TeamDriver");

            migrationBuilder.RenameColumn(
                name: "idDriver",
                table: "TeamDriver",
                newName: "IdDriver");

            migrationBuilder.RenameColumn(
                name: "idTeam",
                table: "TeamDriver",
                newName: "IdTeam");

            migrationBuilder.RenameIndex(
                name: "idDriver_idx",
                table: "TeamDriver",
                newName: "IX_TeamDriver_IdDriver");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamDriver",
                table: "TeamDriver",
                columns: new[] { "IdTeam", "IdDriver" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamDriver_driver_IdDriver",
                table: "TeamDriver",
                column: "IdDriver",
                principalTable: "driver",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamDriver_team_IdTeam",
                table: "TeamDriver",
                column: "IdTeam",
                principalTable: "team",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamDriver_driver_IdDriver",
                table: "TeamDriver");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamDriver_team_IdTeam",
                table: "TeamDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamDriver",
                table: "TeamDriver");

            migrationBuilder.RenameTable(
                name: "TeamDriver",
                newName: "teamdriver");

            migrationBuilder.RenameColumn(
                name: "IdDriver",
                table: "teamdriver",
                newName: "idDriver");

            migrationBuilder.RenameColumn(
                name: "IdTeam",
                table: "teamdriver",
                newName: "idTeam");

            migrationBuilder.RenameIndex(
                name: "IX_TeamDriver_IdDriver",
                table: "teamdriver",
                newName: "idDriver_idx");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "teamdriver",
                columns: new[] { "idTeam", "idDriver" })
                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            migrationBuilder.AddForeignKey(
                name: "idDriver",
                table: "teamdriver",
                column: "idDriver",
                principalTable: "driver",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "idTeam",
                table: "teamdriver",
                column: "idTeam",
                principalTable: "team",
                principalColumn: "id");
        }
    }
}
