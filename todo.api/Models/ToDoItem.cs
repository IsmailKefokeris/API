using System.Diagnostics.CodeAnalysis;

namespace todo.api.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Task { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        //[SetsRequiredMembers]
        //public ToDoItem(int id, string task, string desc, bool isCompleted) 
        //{
        //    Id = id;
        //    Task = task;
        //    Description = desc;
        //    IsCompleted = isCompleted;
        //}
    }
}
