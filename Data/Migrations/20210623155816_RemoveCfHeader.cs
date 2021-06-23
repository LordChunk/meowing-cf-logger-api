using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveCfHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HttpRequests_CfHttpHeaders_CfId",
                table: "HttpRequests");

            migrationBuilder.DropTable(
                name: "CfHttpHeaders");

            migrationBuilder.DropIndex(
                name: "IX_HttpRequests_CfId",
                table: "HttpRequests");

            migrationBuilder.DropColumn(
                name: "CfId",
                table: "HttpRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CfId",
                table: "HttpRequests",
                type: "int",
                nullable: true);

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
                    EdgeRequestKeepAliveStatus = table.Column<int>(type: "int", nullable: false),
                    HttpProtocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestPriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TlsCipher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TlsClientAuthId = table.Column<int>(type: "int", nullable: true),
                    TlsExportedAuthenticatorId = table.Column<int>(type: "int", nullable: true),
                    TlsVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequests_CfId",
                table: "HttpRequests",
                column: "CfId");

            migrationBuilder.CreateIndex(
                name: "IX_CfHttpHeaders_TlsClientAuthId",
                table: "CfHttpHeaders",
                column: "TlsClientAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_CfHttpHeaders_TlsExportedAuthenticatorId",
                table: "CfHttpHeaders",
                column: "TlsExportedAuthenticatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HttpRequests_CfHttpHeaders_CfId",
                table: "HttpRequests",
                column: "CfId",
                principalTable: "CfHttpHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
