using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class IntitialMySQLCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TlsClientAuths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CertIssuerDnrfc2253 = table.Column<string>(nullable: true),
                    CertFingerprintSha1 = table.Column<string>(nullable: true),
                    CertSubjectDnLegacy = table.Column<string>(nullable: true),
                    CertPresented = table.Column<string>(nullable: true),
                    CertIssuerDnLegacy = table.Column<string>(nullable: true),
                    CertSubjectDn = table.Column<string>(nullable: true),
                    CertNotBefore = table.Column<string>(nullable: true),
                    CertNotAfter = table.Column<string>(nullable: true),
                    CertSubjectDnrfc2253 = table.Column<string>(nullable: true),
                    CertVerified = table.Column<string>(nullable: true),
                    CertSerial = table.Column<string>(nullable: true),
                    CertIssuerDn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlsClientAuths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlsExportedAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ServerFinished = table.Column<string>(nullable: true),
                    ClientHandshake = table.Column<string>(nullable: true),
                    ServerHandshake = table.Column<string>(nullable: true),
                    ClientFinished = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlsExportedAuthenticators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CfHttpHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Asn = table.Column<string>(nullable: true),
                    ClientAcceptEncoding = table.Column<string>(nullable: true),
                    ClientTcpRtt = table.Column<int>(nullable: false),
                    Colo = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    TlsVersion = table.Column<string>(nullable: true),
                    TlsCipher = table.Column<string>(nullable: true),
                    EdgeRequestKeepAliveStatus = table.Column<int>(nullable: false),
                    RequestPriority = table.Column<string>(nullable: true),
                    TlsClientAuthId = table.Column<int>(nullable: true),
                    HttpProtocol = table.Column<string>(nullable: true),
                    TlsExportedAuthenticatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CfHttpHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfHttpHeaders_TlsClientAuths_TlsClientAuthId",
                        column: x => x.TlsClientAuthId,
                        principalTable: "TlsClientAuths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthentic~",
                        column: x => x.TlsExportedAuthenticatorId,
                        principalTable: "TlsExportedAuthenticators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: false),
                    CfId = table.Column<int>(nullable: true),
                    Method = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Fetchers = table.Column<string>(nullable: true),
                    BodyUsed = table.Column<bool>(nullable: false),
                    Redirect = table.Column<string>(nullable: true),
                    ContentLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpRequests_CfHttpHeaders_CfId",
                        column: x => x.CfId,
                        principalTable: "CfHttpHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HttpHeaders",
                columns: table => new
                {
                    Header = table.Column<string>(nullable: false),
                    HttpRequestId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpHeaders", x => new { x.Header, x.HttpRequestId });
                    table.ForeignKey(
                        name: "FK_HttpHeaders_HttpRequests_HttpRequestId",
                        column: x => x.HttpRequestId,
                        principalTable: "HttpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CfHttpHeaders_TlsClientAuthId",
                table: "CfHttpHeaders",
                column: "TlsClientAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_CfHttpHeaders_TlsExportedAuthenticatorId",
                table: "CfHttpHeaders",
                column: "TlsExportedAuthenticatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpHeaders_HttpRequestId",
                table: "HttpHeaders",
                column: "HttpRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequests_CfId",
                table: "HttpRequests",
                column: "CfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HttpHeaders");

            migrationBuilder.DropTable(
                name: "HttpRequests");

            migrationBuilder.DropTable(
                name: "CfHttpHeaders");

            migrationBuilder.DropTable(
                name: "TlsClientAuths");

            migrationBuilder.DropTable(
                name: "TlsExportedAuthenticators");
        }
    }
}
