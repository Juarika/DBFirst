using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterDatabase()
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "driver",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         age = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "team",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "teamdriver",
            //     columns: table => new
            //     {
            //         idTeam = table.Column<int>(type: "int", nullable: false),
            //         idDriver = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => new { x.idTeam, x.idDriver })
            //             .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            //         table.ForeignKey(
            //             name: "idDriver",
            //             column: x => x.idDriver,
            //             principalTable: "driver",
            //             principalColumn: "id");
            //         table.ForeignKey(
            //             name: "idTeam",
            //             column: x => x.idTeam,
            //             principalTable: "team",
            //             principalColumn: "id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateIndex(
            //     name: "team_name_IDX",
            //     table: "team",
            //     column: "name",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "idDriver_idx",
            //     table: "teamdriver",
            //     column: "idDriver");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "teamdriver");

            // migrationBuilder.DropTable(
            //     name: "driver");

            // migrationBuilder.DropTable(
            //     name: "team");
        }
    }
}
