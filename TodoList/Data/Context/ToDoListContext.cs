using Microsoft.EntityFrameworkCore;
using TodoList.Data.Entities;

namespace TodoList.Data.Context
{
    public class ToDoListContext : DbContext
    {

        public ToDoListContext(DbContextOptions<ToDoListContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creamos usuarios para que la db tenga registros.
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id_user = 1,
                    Name = "Felipe",
                    Email = "felidegasperi@gmail.com",
                    Address = "San Martin 1094"
                },
                new User
                {
                    Id_user = 2,
                    Name = "Martin",
                    Email = "martin@gmail.com",
                    Address = "Santa Fe 1134"
                });
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id_todo_item = 1,
                    Title = "hacer tp",
                    Description = "enpoints",
                    Id_user = 1
                },
                new TodoItem
                {
                    Id_todo_item = 2,
                    Title = "terminar tp",
                    Description = "subir a git",
                    Id_user = 2
                });


            // Configuración de la relación entre User y TodoItem
            modelBuilder.Entity<TodoItem>()
                .HasOne(t => t.User)                    // Un TodoItem tiene un User
                .WithMany(u => u.TodoItems)             // Un User puede tener muchos TodoItems
                .HasForeignKey(t => t.Id_user);         // Clave foránea en TodoItem
        }
    }
}
