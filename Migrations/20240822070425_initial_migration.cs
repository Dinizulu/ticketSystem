using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bugs",
                columns: table => new
                {
                    bugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bugDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bugSummery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bugSeverity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bugStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bugs", x => x.bugId);
                });

            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    featureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureSummery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.featureId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bugs");

            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
