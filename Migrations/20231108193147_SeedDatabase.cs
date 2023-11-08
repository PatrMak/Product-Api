using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Number, Quantity, Description, Price) VALUES ('Milk', 1, 10, 'Low fat 0.5%', 3.15)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Number, Quantity, Description, Price) VALUES ('Banana', 2, 30, 'From Ughanda', 4.40)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Number, Quantity, Description, Price) VALUES ('Potatoes', 3, 100, 'From Poland', 2.99)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Number, Quantity, Description, Price) VALUES ('Orange juice', 4, 5, 'Only from natural orange', 6.20)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Number, Quantity, Description, Price) VALUES ('Tuna', 5, 5, 'Fresh tuna', 10.99)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products WHERE Name IN ('Milk', 'Banana', 'Potatoes', 'Orange juice', 'Tuna')");
        }
    }
}
