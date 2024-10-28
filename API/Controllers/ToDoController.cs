using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly TodoService _todoService;

    public ToDoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAll()
    {
        var items = await _todoService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetById(int id)
    {
        var item = await _todoService.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItem>> Add(ToDoItemDto toDoItemDto)
    {
        await _todoService.AddAsync(toDoItemDto);
        return CreatedAtAction(nameof(GetById), new {id = toDoItemDto.Id}, null);
        
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ToDoItemDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _todoService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _todoService.DeleteAsync(id);
        return NoContent();
    }
}