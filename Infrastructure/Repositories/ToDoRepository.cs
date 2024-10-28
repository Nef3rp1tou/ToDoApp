using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly List<ToDoItem> _inMemoryToDoList = new();
    
    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        return await Task.FromResult(_inMemoryToDoList);
    }

    public async Task<ToDoItem> GetByIdAsync(int id)
    {
        return await Task.FromResult(_inMemoryToDoList.Find(todo => todo.Id == id));
    }

    public async Task AddAsync(ToDoItem todoItem)
    {
        _inMemoryToDoList.Add(todoItem);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(ToDoItem toDoItem)
    {
        var existingItem = _inMemoryToDoList.Find(x => x.Id == toDoItem.Id);
        if (existingItem != null)
        {
            existingItem.Title = toDoItem.Title;
            existingItem.Description = toDoItem.Description;
            existingItem.IsCompleted = toDoItem.IsCompleted;
            
        }
        await Task.CompletedTask;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var itemToDelete = _inMemoryToDoList.Find(x => x.Id == id);
        if (itemToDelete != null)
        {
            _inMemoryToDoList.Remove(itemToDelete);
        }
        await Task.CompletedTask;
    }
}