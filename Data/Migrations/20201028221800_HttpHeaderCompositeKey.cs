using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class HttpHeaderCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CfHttpHeaders_TlsClientAuths_TlsClientAuthId",
                table: "CfHttpHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthenticatorId",
                table: "CfHttpHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HttpHeaders",
                table: "HttpHeaders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HttpHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "ServerHandshake",
                table: "TlsExportedAuthenticators",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ServerFinished",
                table: "TlsExportedAuthenticators",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClientHandshake",
                table: "TlsExportedAuthenticators",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClientFinished",
                table: "TlsExportedAuthenticators",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertVerified",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertSubjectDnrfc2253",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertSubjectDnLegacy",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertSubjectDn",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertSerial",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertPresented",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertNotBefore",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertNotAfter",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertIssuerDnrfc2253",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertIssuerDnLegacy",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertIssuerDn",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertFingerprintSha1",
                table: "TlsClientAuths",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "HttpHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TlsVersion",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TlsExportedAuthenticatorId",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TlsClientAuthId",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TlsCipher",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RequestPriority",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HttpProtocol",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Colo",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClientAcceptEncoding",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Asn",
                table: "CfHttpHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HttpHeaders",
                table: "HttpHeaders",
                columns: new[] { "Header", "HttpRequestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CfHttpHeaders_TlsClientAuths_TlsClientAuthId",
                table: "CfHttpHeaders",
                column: "TlsClientAuthId",
                principalTable: "TlsClientAuths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthenticatorId",
                table: "CfHttpHeaders",
                column: "TlsExportedAuthenticatorId",
                principalTable: "TlsExportedAuthenticators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CfHttpHeaders_TlsClientAuths_TlsClientAuthId",
                table: "CfHttpHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthenticatorId",
                table: "CfHttpHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HttpHeaders",
                table: "HttpHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "ServerHandshake",
                table: "TlsExportedAuthenticators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServerFinished",
                table: "TlsExportedAuthenticators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientHandshake",
                table: "TlsExportedAuthenticators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientFinished",
                table: "TlsExportedAuthenticators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertVerified",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertSubjectDnrfc2253",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertSubjectDnLegacy",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertSubjectDn",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertSerial",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertPresented",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertNotBefore",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertNotAfter",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertIssuerDnrfc2253",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertIssuerDnLegacy",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertIssuerDn",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertFingerprintSha1",
                table: "TlsClientAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "HttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HttpHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TlsVersion",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TlsExportedAuthenticatorId",
                table: "CfHttpHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TlsClientAuthId",
                table: "CfHttpHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TlsCipher",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestPriority",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HttpProtocol",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Colo",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientAcceptEncoding",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Asn",
                table: "CfHttpHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HttpHeaders",
                table: "HttpHeaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CfHttpHeaders_TlsClientAuths_TlsClientAuthId",
                table: "CfHttpHeaders",
                column: "TlsClientAuthId",
                principalTable: "TlsClientAuths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CfHttpHeaders_TlsExportedAuthenticators_TlsExportedAuthenticatorId",
                table: "CfHttpHeaders",
                column: "TlsExportedAuthenticatorId",
                principalTable: "TlsExportedAuthenticators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
