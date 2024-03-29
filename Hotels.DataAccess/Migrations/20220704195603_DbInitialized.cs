﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.DataAccess.Migrations
{
    public partial class DbInitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    MinPrice = table.Column<double>(type: "float", nullable: false),
                    MaxPrice = table.Column<double>(type: "float", nullable: false),
                    Occupancies = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevatorAccess = table.Column<bool>(type: "bit", nullable: false),
                    FitnessCenter = table.Column<bool>(type: "bit", nullable: false),
                    ContactLessCheckIn = table.Column<bool>(type: "bit", nullable: false),
                    ProfessionalyClean = table.Column<bool>(type: "bit", nullable: false),
                    Support24by7 = table.Column<bool>(type: "bit", nullable: false),
                    OutdoorSpace = table.Column<bool>(type: "bit", nullable: false),
                    SwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    FreeParking = table.Column<bool>(type: "bit", nullable: false),
                    FreeWifi = table.Column<bool>(type: "bit", nullable: false),
                    LuggageStorage = table.Column<bool>(type: "bit", nullable: false),
                    IndoorGames = table.Column<bool>(type: "bit", nullable: false),
                    LoungeAndWorkSpace = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsTrending = table.Column<bool>(type: "bit", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayPriceRaw = table.Column<double>(type: "float", nullable: false),
                    MaxOccupancies = table.Column<int>(type: "int", nullable: false),
                    BedCount = table.Column<int>(type: "int", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    ServiceCharge = table.Column<double>(type: "float", nullable: false),
                    DiscountedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingBedCount = table.Column<bool>(type: "bit", nullable: false),
                    QueenBedCount = table.Column<bool>(type: "bit", nullable: false),
                    SofaBedCount = table.Column<bool>(type: "bit", nullable: false),
                    Dishwasher = table.Column<bool>(type: "bit", nullable: false),
                    Microwave = table.Column<bool>(type: "bit", nullable: false),
                    ElectricKettle = table.Column<bool>(type: "bit", nullable: false),
                    IroningSet = table.Column<bool>(type: "bit", nullable: false),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    Television = table.Column<bool>(type: "bit", nullable: false),
                    FreeWifi = table.Column<bool>(type: "bit", nullable: false),
                    InSuiteLaundry = table.Column<bool>(type: "bit", nullable: false),
                    StreamingDevice = table.Column<bool>(type: "bit", nullable: false),
                    StockedKitchen = table.Column<bool>(type: "bit", nullable: false),
                    MountainOrHillView = table.Column<bool>(type: "bit", nullable: false),
                    NonSmokingRoom = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67d8d052-e045-487b-ae10-66e78eff650d", "1e3334cf-2bd6-4261-9502-4e0816e8d396", "Administrator", "ADMINISTRATOR" },
                    { "c4fce0cd-20e9-4745-a209-5c7f51ba8be6", "b5c132b3-4c79-40ef-b4f5-2dfad322e6fd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Division", "IsFeatured", "Name" },
                values: new object[,]
                {
                    { 1, "Bangladesh", "Dhaka", true, "Dhaka" },
                    { 2, "Bangladesh", "Chittagong", true, "Chittagong" },
                    { 3, "Bangladesh", "Comilla", true, "Comilla" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "MaxPrice", "MinPrice", "Name", "Occupancies", "Rating", "RoomCount" },
                values: new object[] { 1, "79/A Commercial Area Airport Rd, Dhaka-1229", 1, "Luxe, modern lodging offering elegant rooms & suites, plus an infinity pool & chic dining.", 25000.0, 4000.0, "Le Méridien", 3, 4.5999999999999996, 44 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "MaxPrice", "MinPrice", "Name", "Occupancies", "Rating", "RoomCount" },
                values: new object[] { 2, "Shahid Saifuddin Khaled Rd, Chattogram-4000", 2, "Polished quarters in a contemporary hotel offering an infinity pool, a spa & 3 restaurants.", 25000.0, 4000.0, "Radisson Blu Chattogram Bay View", 3, 4.5999999999999996, 44 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "MaxPrice", "MinPrice", "Name", "Occupancies", "Rating", "RoomCount" },
                values: new object[] { 3, "931 Laksham Rd, Cumilla-3501", 3, "Laid-back hotel featuring a restaurant & a fitness room, as well as breakfast & parking.", 25000.0, 4000.0, "OASIS Hotel", 3, 4.0, 44 });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "ContactLessCheckIn", "ElevatorAccess", "FitnessCenter", "FreeParking", "FreeWifi", "HotelId", "IndoorGames", "LoungeAndWorkSpace", "LuggageStorage", "OutdoorSpace", "ProfessionalyClean", "Support24by7", "SwimmingPool" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, 1, true, true, true, true, true, true, true },
                    { 2, true, true, true, true, true, 2, true, true, true, true, true, true, true },
                    { 3, true, true, true, true, true, 3, true, true, true, true, true, true, true }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BathroomCount", "BedCount", "CheckIn", "CheckOut", "DiscountedPrice", "DisplayPrice", "DisplayPriceRaw", "HotelId", "IsAvailable", "IsBooked", "IsFavourite", "IsTrending", "MaxOccupancies", "Name", "ServiceCharge", "Type" },
                values: new object[,]
                {
                    { 1, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "$321", 321.35000000000002, 1, true, false, false, true, 6, "Studio Apartment", 15.0, 8 },
                    { 2, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "$321", 321.35000000000002, 2, true, false, false, true, 6, "Double Deluxe", 15.0, 4 },
                    { 3, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "$321", 321.35000000000002, 3, true, false, false, true, 6, "Twin Deluxe", 15.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "Dishwasher", "ElectricKettle", "FreeWifi", "InSuiteLaundry", "IroningSet", "KingBedCount", "Microwave", "MountainOrHillView", "NonSmokingRoom", "QueenBedCount", "RoomId", "SofaBedCount", "StockedKitchen", "StreamingDevice", "Television" },
                values: new object[] { 1, true, true, true, true, true, true, true, true, true, true, true, 1, true, true, true, true });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "Dishwasher", "ElectricKettle", "FreeWifi", "InSuiteLaundry", "IroningSet", "KingBedCount", "Microwave", "MountainOrHillView", "NonSmokingRoom", "QueenBedCount", "RoomId", "SofaBedCount", "StockedKitchen", "StreamingDevice", "Television" },
                values: new object[] { 2, true, true, true, true, true, true, true, true, true, true, true, 2, true, true, true, true });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "Dishwasher", "ElectricKettle", "FreeWifi", "InSuiteLaundry", "IroningSet", "KingBedCount", "Microwave", "MountainOrHillView", "NonSmokingRoom", "QueenBedCount", "RoomId", "SofaBedCount", "StockedKitchen", "StreamingDevice", "Television" },
                values: new object[] { 3, true, true, true, true, true, true, true, true, true, true, true, 3, true, true, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_HotelId",
                table: "Facilities",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
