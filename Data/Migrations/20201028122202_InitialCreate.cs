using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TlsClientAuths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertIssuerDnrfc2253 = table.Column<string>(nullable: false),
                    CertFingerprintSha1 = table.Column<string>(nullable: false),
                    CertSubjectDnLegacy = table.Column<string>(nullable: false),
                    CertPresented = table.Column<string>(nullable: false),
                    CertIssuerDnLegacy = table.Column<string>(nullable: false),
                    CertSubjectDn = table.Column<string>(nullable: false),
                    CertNotBefore = table.Column<string>(nullable: false),
                    CertNotAfter = table.Column<string>(nullable: false),
                    CertSubjectDnrfc2253 = table.Column<string>(nullable: false),
                    CertVerified = table.Column<string>(nullable: false),
                    CertSerial = table.Column<string>(nullable: false),
                    CertIssuerDn = table.Column<string>(nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerFinished = table.Column<string>(nullable: false),
                    ClientHandshake = table.Column<string>(nullable: false),
                    ServerHandshake = table.Column<string>(nullable: false),
                    ClientFinished = table.Column<string>(nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asn = table.Column<string>(nullable: false),
                    ClientAcceptEncoding = table.Column<string>(nullable: false),
                    ClientTcpRtt = table.Column<int>(nullable: false),
                    Colo = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    TlsVersion = table.Column<string>(nullable: false),
                    TlsCipher = table.Column<string>(nullable: false),
                    EdgeRequestKeepAliveStatus = table.Column<int>(nullable: false),
                    RequestPriority = table.Column<string>(nullable: false),
                    TlsClientAuthId = table.Column<int>(nullable: false),
                    HttpProtocol = table.Column<string>(nullable: false),
                    TlsExportedAuthenticatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CfHttpHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfHttpHeaders_TlsClientAuths_TlsClientAuthId",
                        column: x => x.TlsClientAuthId,
                        principalTable: "TlsClientAuths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthenticatorId",
                        column: x => x.TlsExportedAuthenticatorId,
                        principalTable: "TlsExportedAuthenticators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    HttpRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpHeaders", x => x.Id);
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
