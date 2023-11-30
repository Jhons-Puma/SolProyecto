using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolProyecto.Migrations
{
    public partial class PrimeraCarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    numeroDocumento = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    clave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TbProducto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(nullable: false),
                    marca = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    precioInicial = table.Column<double>(nullable: true),
                    descuento = table.Column<double>(nullable: true),
                    precioFinal = table.Column<double>(nullable: true),
                    stock = table.Column<int>(nullable: false),
                    envio = table.Column<bool>(nullable: true),
                    delibery = table.Column<bool>(nullable: true),
                    retiroTienda = table.Column<bool>(nullable: true),
                    imgURL = table.Column<string>(nullable: true),
                    descripcipn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProducto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TbPedido",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(nullable: false),
                    fechaOrden = table.Column<DateTime>(nullable: false),
                    tarjetaCredito = table.Column<string>(nullable: true),
                    fechaVenCredito = table.Column<string>(nullable: true),
                    CVV = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    TbClienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_TbPedido_TbCliente_TbClienteid",
                        column: x => x.TbClienteid,
                        principalTable: "TbCliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbDetallePedido",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(nullable: false),
                    precioFinal = table.Column<double>(nullable: true),
                    TbProductoid = table.Column<int>(nullable: true),
                    TbPedidoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDetallePedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_TbDetallePedido_TbPedido_TbPedidoid",
                        column: x => x.TbPedidoid,
                        principalTable: "TbPedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbDetallePedido_TbProducto_TbProductoid",
                        column: x => x.TbProductoid,
                        principalTable: "TbProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbDetallePedido_TbPedidoid",
                table: "TbDetallePedido",
                column: "TbPedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_TbDetallePedido_TbProductoid",
                table: "TbDetallePedido",
                column: "TbProductoid");

            migrationBuilder.CreateIndex(
                name: "IX_TbPedido_TbClienteid",
                table: "TbPedido",
                column: "TbClienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbDetallePedido");

            migrationBuilder.DropTable(
                name: "TbPedido");

            migrationBuilder.DropTable(
                name: "TbProducto");

            migrationBuilder.DropTable(
                name: "TbCliente");
        }
    }
}
