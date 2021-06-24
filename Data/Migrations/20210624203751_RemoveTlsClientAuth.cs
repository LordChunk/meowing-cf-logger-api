using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveTlsClientAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TlsClientAuths");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TlsClientAuths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertFingerprintSha1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertIssuerDn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertIssuerDnLegacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertIssuerDnrfc2253 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertNotAfter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertNotBefore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertPresented = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSubjectDn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSubjectDnLegacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSubjectDnrfc2253 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertVerified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlsClientAuths", x => x.Id);
                });
        }
    }
}
