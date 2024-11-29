using Microsoft.EntityFrameworkCore;
using todo.api.Interfaces;
using todo.api.Models;

namespace todo.api.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly DataContext _context;

        public ToDoItemRepository(DataContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<IList<ToDoItem>> GetAll()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetItemById(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<IList<ToDoItem>> AddItem(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();

            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<IList<ToDoItem>> UpdateItem(ToDoItem item)
        {
            var dbItem = await GetItemById(item.Id);
            if (dbItem == null)
            {
                return null;
            }

            dbItem.Task = item.Task;
            dbItem.Description = item.Description;
            dbItem.IsCompleted = item.IsCompleted;

            await _context.SaveChangesAsync();

            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<IList<ToDoItem>> DeleteItem(int id)
        {
            var dbItem = await _context.ToDoItems.FindAsync(id);
            if (dbItem == null)
            {
                return null;
            }

            _context.ToDoItems.Remove(dbItem);
            await _context.SaveChangesAsync();

            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<IList<ToDoItem>> UpdateIsCompleted(int id)
        {
            var dbItem = await GetItemById(id);
            if (dbItem == null)
            {
                return null;
            }

            dbItem.IsCompleted = !dbItem.IsCompleted;

            await _context.SaveChangesAsync();

            return await _context.ToDoItems.ToListAsync();
        }

        
    }
}
