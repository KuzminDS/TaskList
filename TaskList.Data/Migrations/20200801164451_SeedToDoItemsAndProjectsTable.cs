using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskList.Data.Migrations
{
    public partial class SeedToDoItemsAndProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Projects (Name, IsCompleted) Values ('Create a web site', 0)");

            migrationBuilder
                .Sql("INSERT INTO ToDoItems (Name, IsCompleted, IsFromInbox, ProjectId) " +
                     "Values ('Write HTML page', 0, 0, (SELECT ProjectId FROM Projects WHERE Name = 'Create a web site'))");
            migrationBuilder
                .Sql("INSERT INTO ToDoItems (Name, IsCompleted, IsFromInbox, ProjectId) " +
                     "Values ('Write CSS styles', 0, 0, (SELECT ProjectId FROM Projects WHERE Name = 'Create a web site'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM ToDoItems");

            migrationBuilder
                .Sql("DELETE FROM Projects");
        }
    }
}
