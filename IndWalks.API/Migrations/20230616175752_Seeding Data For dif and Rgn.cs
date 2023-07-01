using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndWalks.API.Migrations
{
    public partial class SeedingDataFordifandRgn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("63c4329a-110e-42ba-9620-37e2a90704b3"), "Hard" },
                    { new Guid("678f796d-a48c-47cc-a9b7-891718324003"), "Medium" },
                    { new Guid("736f1151-403e-499d-b38b-1c021f31cc86"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "ARS", "Arebian Sea", null },
                    { new Guid("57b4e693-11d4-4220-a8c6-bcff4fc841f1"), "Matheran", "MTRN", "AnyImage.jpg" },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NRL", "Neral", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "KAN", "Kandivali", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "CST", "Shivaji Maharaj Terminus", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "BVI", "Borivali", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("63c4329a-110e-42ba-9620-37e2a90704b3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("678f796d-a48c-47cc-a9b7-891718324003"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("736f1151-403e-499d-b38b-1c021f31cc86"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("57b4e693-11d4-4220-a8c6-bcff4fc841f1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));
        }
    }
}
