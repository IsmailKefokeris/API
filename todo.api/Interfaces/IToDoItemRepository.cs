using todo.api.Models;

namespace todo.api.Interfaces
{
    public interface IToDoItemRepository
    {

        Task<IList<ToDoItem>> GetAll();
        Task<ToDoItem> GetItemById(int id);
        Task<IList<ToDoItem>> AddItem(ToDoItem item);
        Task<IList<ToDoItem>> UpdateItem(ToDoItem item);
        Task<IList<ToDoItem>> UpdateIsCompleted(int id);
        Task<IList<ToDoItem>> DeleteItem(int id);
    }
}
