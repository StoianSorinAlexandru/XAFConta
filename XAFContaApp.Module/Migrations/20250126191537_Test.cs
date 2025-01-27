using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XAFContaApp.Module.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gestions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reports_Gestions_GestionID",
                        column: x => x.GestionID,
                        principalTable: "Gestions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entries_Gestions_GestionID",
                        column: x => x.GestionID,
                        principalTable: "Gestions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Entries_Partners_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partners",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Exits",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exits_Gestions_GestionID",
                        column: x => x.GestionID,
                        principalTable: "Gestions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Exits_Partners_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partners",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DetailedEntries",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryId = table.Column<Guid>(name: "Entry.Id", type: "uniqueidentifier", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedEntries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetailedEntries_Entries_Entry.Id",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DetailedEntries_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DetailedExits",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExitId = table.Column<Guid>(name: "Exit.Id", type: "uniqueidentifier", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedExits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetailedExits_Exits_Exit.Id",
                        column: x => x.ExitId,
                        principalTable: "Exits",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DetailedExits_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEntries_Entry.Id",
                table: "DetailedEntries",
                column: "Entry.Id",
                unique: true,
                filter: "[Entry.Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEntries_ProductID",
                table: "DetailedEntries",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedExits_Exit.Id",
                table: "DetailedExits",
                column: "Exit.Id",
                unique: true,
                filter: "[Exit.Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedExits_ProductID",
                table: "DetailedExits",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_GestionID",
                table: "Entries",
                column: "GestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PartnerID",
                table: "Entries",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Exits_GestionID",
                table: "Exits",
                column: "GestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Exits_PartnerID",
                table: "Exits",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_GestionID",
                table: "Reports",
                column: "GestionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailedEntries");

            migrationBuilder.DropTable(
                name: "DetailedExits");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Exits");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Gestions");

            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
