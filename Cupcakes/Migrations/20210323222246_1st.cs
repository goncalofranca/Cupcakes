﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cupcakes.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bakeries",
                columns: table => new
                {
                    BakeryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakeryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bakeries", x => x.BakeryID);
                });

            migrationBuilder.CreateTable(
                name: "Cupcakes",
                columns: table => new
                {
                    CupcakeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CupcakeType = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GlutenFree = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageMimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BakeryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupcakes", x => x.CupcakeID);
                    table.ForeignKey(
                        name: "FK_Cupcakes_Bakeries_BakeryID",
                        column: x => x.BakeryID,
                        principalTable: "Bakeries",
                        principalColumn: "BakeryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bakeries",
                columns: new[] { "BakeryID", "Address", "BakeryName", "Quantity" },
                values: new object[,]
                {
                    { 1, "635 Brighton Circle Road", "Gluteus Free", 8 },
                    { 2, "4323 Jerome Avenue", "Cupcakes Break", 22 },
                    { 3, "2553 Pin Oak Drive", "Cupcakes Ahead", 18 },
                    { 4, "1608 Charles Street", "Sugar", 30 }
                });

            migrationBuilder.InsertData(
                table: "Cupcakes",
                columns: new[] { "CupcakeID", "BakeryID", "CupcakeType", "Description", "GlutenFree", "ImageMimeType", "ImageName", "PhotoFile", "Price" },
                values: new object[,]
                {
                    { 1, 1, 0, "Vanilla cupcake with coconut cream", true, "image/jpeg", "birthday-cupcake.jpg", null, 2.5 },
                    { 2, 2, 2, "Chocolate cupcake with caramel filling and chocolate butter cream", false, "image/jpeg", "chocolate-cupcake.jpg", null, 3.2000000000000002 },
                    { 3, 3, 3, "Chocolate cupcake with straberry cream filling", false, "image/jpeg", "pink-cupcake.jpg", null, 4.0 },
                    { 4, 4, 1, "Vanilla cupcake with butter cream", true, "image/jpeg", "turquoise-cupcake.jpg", null, 1.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cupcakes_BakeryID",
                table: "Cupcakes",
                column: "BakeryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupcakes");

            migrationBuilder.DropTable(
                name: "Bakeries");
        }
    }
}
