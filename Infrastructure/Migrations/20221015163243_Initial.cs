using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => new { x.CartId, x.ItemId });
                });

            migrationBuilder.CreateTable(
                name: "CartItemDbSetItemDbSet",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartItemCartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CartItemItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemDbSetItemDbSet", x => new { x.ItemId, x.CartItemCartId, x.CartItemItemId });
                    table.ForeignKey(
                        name: "FK_CartItemDbSetItemDbSet_CartItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "CartItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItemDbSetItemDbSet_Items_CartItemCartId_CartItemItemId",
                        columns: x => new { x.CartItemCartId, x.CartItemItemId },
                        principalTable: "Items",
                        principalColumns: new[] { "CartId", "ItemId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ItemId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "https://picsum.photos/200/300", "iPhone 12", 50000m });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ItemId", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "https://picsum.photos/200/300", "HP Laptop", 50000m });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ItemId", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "https://picsum.photos/200/300", "Samsung S22 Ultra", 84000m });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemDbSetItemDbSet_CartItemCartId_CartItemItemId",
                table: "CartItemDbSetItemDbSet",
                columns: new[] { "CartItemCartId", "CartItemItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemDbSetItemDbSet");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
