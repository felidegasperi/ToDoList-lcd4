using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id_todo_item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id_todo_item);
                    table.ForeignKey(
                        name: "FK_TodoItems_Users_Id_user",
                        column: x => x.Id_user,
                        principalTable: "Users",
                        principalColumn: "Id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_user", "Address", "Email", "Name" },
                values: new object[] { 1, "San Martin 1094", "felidegasperi@gmail.com", "Felipe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_user", "Address", "Email", "Name" },
                values: new object[] { 2, "Santa Fe 1134", "martin@gmail.com", "Martin" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_todo_item", "Description", "Id_user", "Title" },
                values: new object[] { 1, "enpoints", 1, "hacer tp" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_todo_item", "Description", "Id_user", "Title" },
                values: new object[] { 2, "subir a git", 2, "terminar tp" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_Id_user",
                table: "TodoItems",
                column: "Id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
