using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class TodoService(IToDoRepository toDoRepository)
{
    private readonly IToDoRepository _toDoRepository = toDoRepository;

    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        var items = await _toDoRepository.GetAllAsync();
        var result = new List<ToDoItem>();

        foreach (var item in items)
        {
            result.Add(new ToDoItem
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            });
        }
        return result;
    }

    public async Task<ToDoItem> GetByIdAsync(int id)
    {
        var item = await _toDoRepository.GetByIdAsync(id);
        
        if(item == null) return null;
        return new ToDoItem
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            IsCompleted = item.IsCompleted
        };
    }

    public async Task AddAsync(ToDoItemDto dto)
    {
        var itemToAdd = new ToDoItem
        {
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted
        };
        await _toDoRepository.AddAsync(itemToAdd);
    }

    public async Task UpdateAsync(ToDoItemDto dto)
    {
        var itemToUpdate = new ToDoItem
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted
        };
        await _toDoRepository.UpdateAsync(itemToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        await _toDoRepository.DeleteByIdAsync(id);
    }
}