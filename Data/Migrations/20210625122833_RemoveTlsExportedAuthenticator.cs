using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveTlsExportedAuthenticator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TlsExportedAuthenticators");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TlsExportedAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFinished = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientHandshake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerFinished = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerHandshake = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlsExportedAuthenticators", x => x.Id);
                });
        }
    }
}
