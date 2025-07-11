﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CapacityValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CapacityUnit = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    CurrentCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChargeCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxChargeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxDischargeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CycleCount = table.Column<int>(type: "int", nullable: true),
                    StateOfHealth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DCInput = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ACOutput = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DCVoltage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ACVoltage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Frequency = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inverter_Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TiltAngle = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Azimuth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SiteId",
                table: "Assets",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Status",
                table: "Assets",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Type",
                table: "Assets",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Name",
                table: "Sites",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
