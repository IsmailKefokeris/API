using Microsoft.EntityFrameworkCore;
using todo.api.Models;

namespace todo.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
