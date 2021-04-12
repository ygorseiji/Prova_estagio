using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication9.Migrations
{
    public partial class initializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbVendedor",
                columns: table => new
                {
                    CDVEND = table.Column<Guid>(type: "TEXT", nullable: false),
                    DSNOME = table.Column<string>(type: "TEXT", nullable: true),
                    CDTAB = table.Column<int>(type: "INTEGER", nullable: false),
                    DTNASC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbVendedor", x => x.CDVEND);
                });

            migrationBuilder.CreateTable(
                name: "dbCliente",
                columns: table => new
                {
                    CDCL = table.Column<Guid>(type: "TEXT", nullable: false),
                    DSNOME = table.Column<string>(type: "TEXT", nullable: true),
                    IDTIPO = table.Column<string>(type: "TEXT", nullable: true),
                    CDVEND = table.Column<Guid>(type: "TEXT", nullable: false),
                    vendedorCDVEND = table.Column<Guid>(type: "TEXT", nullable: true),
                    DSLIM = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbCliente", x => x.CDCL);
                    table.ForeignKey(
                        name: "FK_dbCliente_dbVendedor_vendedorCDVEND",
                        column: x => x.vendedorCDVEND,
                        principalTable: "dbVendedor",
                        principalColumn: "CDVEND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbCliente_vendedorCDVEND",
                table: "dbCliente",
                column: "vendedorCDVEND");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbCliente");

            migrationBuilder.DropTable(
                name: "dbVendedor");
        }
    }
}
