using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAIXA",
                columns: table => new
                {
                    IDCAIXA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ALTURA = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    LARGURA = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    COMPRIMENTO = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAIXA", x => x.IDCAIXA);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    IDPEDIDO = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.IDPEDIDO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    IDPRODUTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ALTURA = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    LARGURA = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    COMPRIMENTO = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.IDPRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO_PRODUTO",
                columns: table => new
                {
                    IDPEDIDOPRODUTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPEDIDO = table.Column<int>(type: "int", nullable: false),
                    IDPRODUTO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO_PRODUTO", x => x.IDPEDIDOPRODUTO);
                    table.ForeignKey(
                        name: "FK_PEDIDO_PRODUTO_PEDIDO_IDPEDIDO",
                        column: x => x.IDPEDIDO,
                        principalTable: "PEDIDO",
                        principalColumn: "IDPEDIDO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDO_PRODUTO_PRODUTO_IDPRODUTO",
                        column: x => x.IDPRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "IDPRODUTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_PRODUTO_IDPEDIDO",
                table: "PEDIDO_PRODUTO",
                column: "IDPEDIDO");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_PRODUTO_IDPRODUTO",
                table: "PEDIDO_PRODUTO",
                column: "IDPRODUTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAIXA");

            migrationBuilder.DropTable(
                name: "PEDIDO_PRODUTO");

            migrationBuilder.DropTable(
                name: "PEDIDO");

            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
