using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyData.Migrations
{
    /// <inheritdoc />
    public partial class Inıt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "Turler",
                schema: "security",
                columns: table => new
                {
                    TurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.TurId);
                });

            

            migrationBuilder.CreateTable(
                name: "Cinsler",
                schema: "security",
                columns: table => new
                {
                    CinsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsler", x => x.CinsId);
                    table.ForeignKey(
                        name: "FK_Cinsler_Turler_TurId",
                        column: x => x.TurId,
                        principalSchema: "security",
                        principalTable: "Turler",
                        principalColumn: "TurId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hayvanlar",
                schema: "security",
                columns: table => new
                {
                    HayvanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Yas = table.Column<int>(type: "int", nullable: true),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurId = table.Column<int>(type: "int", nullable: true),
                    CinsId = table.Column<int>(type: "int", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resim1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resim2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resim3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvanlar", x => x.HayvanId);
                    table.ForeignKey(
                        name: "FK_Hayvanlar_Cinsler_CinsId",
                        column: x => x.CinsId,
                        principalSchema: "security",
                        principalTable: "Cinsler",
                        principalColumn: "CinsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hayvanlar_Turler_TurId",
                        column: x => x.TurId,
                        principalSchema: "security",
                        principalTable: "Turler",
                        principalColumn: "TurId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hayvanlar_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asilar",
                schema: "security",
                columns: table => new
                {
                    AsiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvanID = table.Column<int>(type: "int", nullable: false),
                    AsiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsiTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonrakiAsiTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asilar", x => x.AsiID);
                    table.ForeignKey(
                        name: "FK_Asilar_Hayvanlar_HayvanID",
                        column: x => x.HayvanID,
                        principalSchema: "security",
                        principalTable: "Hayvanlar",
                        principalColumn: "HayvanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bakimlar",
                schema: "security",
                columns: table => new
                {
                    BakimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvanID = table.Column<int>(type: "int", nullable: false),
                    BakimTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BakimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonrakiBakimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bakimlar", x => x.BakimID);
                    table.ForeignKey(
                        name: "FK_Bakimlar_Hayvanlar_HayvanID",
                        column: x => x.HayvanID,
                        principalSchema: "security",
                        principalTable: "Hayvanlar",
                        principalColumn: "HayvanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iliskiler",
                schema: "security",
                columns: table => new
                {
                    IliskiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hayvan1Id = table.Column<int>(type: "int", nullable: false),
                    Hayvan2Id = table.Column<int>(type: "int", nullable: false),
                    IliskiTuru = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iliskiler", x => x.IliskiId);
                    table.ForeignKey(
                        name: "FK_Iliskiler_Hayvanlar_Hayvan1Id",
                        column: x => x.Hayvan1Id,
                        principalSchema: "security",
                        principalTable: "Hayvanlar",
                        principalColumn: "HayvanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iliskiler_Hayvanlar_Hayvan2Id",
                        column: x => x.Hayvan2Id,
                        principalSchema: "security",
                        principalTable: "Hayvanlar",
                        principalColumn: "HayvanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asilar_HayvanID",
                schema: "security",
                table: "Asilar",
                column: "HayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_Bakimlar_HayvanID",
                schema: "security",
                table: "Bakimlar",
                column: "HayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_Cinsler_TurId",
                schema: "security",
                table: "Cinsler",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_CinsId",
                schema: "security",
                table: "Hayvanlar",
                column: "CinsId");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_TurId",
                schema: "security",
                table: "Hayvanlar",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_UserId",
                schema: "security",
                table: "Hayvanlar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Iliskiler_Hayvan1Id",
                schema: "security",
                table: "Iliskiler",
                column: "Hayvan1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Iliskiler_Hayvan2Id",
                schema: "security",
                table: "Iliskiler",
                column: "Hayvan2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asilar",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Bakimlar",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Iliskiler",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Hayvanlar",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Cinsler",
                schema: "security");

            migrationBuilder.DropTable(
                name: "User",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Turler",
                schema: "security");
        }
    }
}
