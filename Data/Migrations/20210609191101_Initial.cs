using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HttpHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlsClientAuths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertIssuerDnrfc2253 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertFingerprintSha1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSubjectDnLegacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertPresented = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertIssuerDnLegacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSubjectDn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertNotBefore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertNotAfter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSubjectDnrfc2253 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertVerified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertIssuerDn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlsClientAuths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlsExportedAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerFinished = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientHandshake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerHandshake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientFinished = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlsExportedAuthenticators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CfHttpHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientAcceptEncoding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientTcpRtt = table.Column<int>(type: "int", nullable: false),
                    Colo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TlsVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TlsCipher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdgeRequestKeepAliveStatus = table.Column<int>(type: "int", nullable: false),
                    RequestPriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TlsClientAuthId = table.Column<int>(type: "int", nullable: true),
                    HttpProtocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TlsExportedAuthenticatorId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthenticatorId",
                        column: x => x.TlsExportedAuthenticatorId,
                        principalTable: "TlsExportedAuthenticators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CfId = table.Column<int>(type: "int", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fetchers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyUsed = table.Column<bool>(type: "bit", nullable: false),
                    Redirect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentLength = table.Column<int>(type: "int", nullable: false)
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
                name: "HttpHeaderHttpRequest",
                columns: table => new
                {
                    HeadersId = table.Column<int>(type: "int", nullable: false),
                    HttpRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpHeaderHttpRequest", x => new { x.HeadersId, x.HttpRequestId });
                    table.ForeignKey(
                        name: "FK_HttpHeaderHttpRequest_HttpHeaders_HeadersId",
                        column: x => x.HeadersId,
                        principalTable: "HttpHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HttpHeaderHttpRequest_HttpRequests_HttpRequestId",
                        column: x => x.HttpRequestId,
                        principalTable: "HttpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequestLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    RequestSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpRequestLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpRequestLog_HttpRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "HttpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_HttpHeaderHttpRequest_HttpRequestId",
                table: "HttpHeaderHttpRequest",
                column: "HttpRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpHeaders_Header_Value",
                table: "HttpHeaders",
                columns: new[] { "Header", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLog_RequestId",
                table: "HttpRequestLog",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequests_CfId",
                table: "HttpRequests",
                column: "CfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HttpHeaderHttpRequest");

            migrationBuilder.DropTable(
                name: "HttpRequestLog");

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
