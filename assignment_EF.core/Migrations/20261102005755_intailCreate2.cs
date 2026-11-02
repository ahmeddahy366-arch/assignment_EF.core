using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace assignment_EF.core.Migrations
{
    /// <inheritdoc />
    public partial class intailCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "categoryId" },
                values: new object[,]
                {
                    { 1, "All programming courses", "Programming", null },
                    { 4, "All data science courses", "Data Science", null },
                    { 2, "All web development courses", "Web Development", 1 },
                    { 3, "All mobile development courses", "Mobile Development", 1 },
                    { 5, "All machine learning courses", "Machine Learning", 4 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "IsPublished", "Level", "Price", "PublishedDate", "categoryId", "description", "instructorid", "title" },
                values: new object[,]
                {
                    { 1, true, 0, 199.99m, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Learn the fundamentals of C# programming language.", 1, "C# Programming" },
                    { 4, false, 0, 349.99m, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Learn data analysis and machine learning using Python.", 1, "Data Science with Python" },
                    { 6, true, 2, 449.99m, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Deep dive into advanced topics of C# programming language.", 3, "Advanced C# Programming" },
                    { 2, true, 1, 249.99m, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Build web applications using ASP.NET Core framework.", 2, "ASP.NET Core Web Development" },
                    { 3, true, 1, 299.99m, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Create cross-platform mobile applications using Xamarin.", 3, "Mobile App Development with Xamarin" },
                    { 5, true, 2, 399.99m, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Introduction to machine learning concepts and algorithms.", 2, "Machine Learning Fundamentals" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
