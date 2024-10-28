using Domain.Entities;

namespace Domain.Interfaces;

public interface IToDoRepository
{
    Task<IEnumerable<ToDoItem>> GetAllAsync();
    Task<ToDoItem> GetByIdAsync(int id);
    Task AddAsync(ToDoItem todoItem);
    Task UpdateAsync(ToDoItem toDoItem);
    Task DeleteByIdAsync(int id);
}