using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RequestUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HttpHeaderHttpRequest_HttpRequests_HttpRequestId",
                table: "HttpHeaderHttpRequest");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "HttpRequests");

            migrationBuilder.RenameColumn(
                name: "HttpRequestId",
                table: "HttpHeaderHttpRequest",
                newName: "HttpRequestsId");

            migrationBuilder.RenameIndex(
                name: "IX_HttpHeaderHttpRequest_HttpRequestId",
                table: "HttpHeaderHttpRequest",
                newName: "IX_HttpHeaderHttpRequest_HttpRequestsId");

            migrationBuilder.AddColumn<int>(
                name: "UrlId",
                table: "HttpRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RequestUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestUrl", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequests_UrlId",
                table: "HttpRequests",
                column: "UrlId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestUrl_Url",
                table: "RequestUrl",
                column: "Url",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HttpHeaderHttpRequest_HttpRequests_HttpRequestsId",
                table: "HttpHeaderHttpRequest",
                column: "HttpRequestsId",
                principalTable: "HttpRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HttpRequests_RequestUrl_UrlId",
                table: "HttpRequests",
                column: "UrlId",
                principalTable: "RequestUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HttpHeaderHttpRequest_HttpRequests_HttpRequestsId",
                table: "HttpHeaderHttpRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_HttpRequests_RequestUrl_UrlId",
                table: "HttpRequests");

            migrationBuilder.DropTable(
                name: "RequestUrl");

            migrationBuilder.DropIndex(
                name: "IX_HttpRequests_UrlId",
                table: "HttpRequests");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "HttpRequests");

            migrationBuilder.RenameColumn(
                name: "HttpRequestsId",
                table: "HttpHeaderHttpRequest",
                newName: "HttpRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_HttpHeaderHttpRequest_HttpRequestsId",
                table: "HttpHeaderHttpRequest",
                newName: "IX_HttpHeaderHttpRequest_HttpRequestId");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "HttpRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_HttpHeaderHttpRequest_HttpRequests_HttpRequestId",
                table: "HttpHeaderHttpRequest",
                column: "HttpRequestId",
                principalTable: "HttpRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
