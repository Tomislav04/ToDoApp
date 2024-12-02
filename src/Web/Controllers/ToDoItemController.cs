using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.TodoItems.Commands.CreateTodoItem;
using ToDoApp.Application.Common.Exceptions;
using ToDoApp.Application.TodoItems.Commands.DeleteTodoItem;
using ToDoApp.Application.TodoItems.Commands.CompleteTodoItem;

namespace ToDoApp.Web.Controllers;

public class ToDoItemController : Controller
{
    private readonly ISender _sender;

    public ToDoItemController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            TempData["Errors"] = string.Join("\n", ex.Errors.SelectMany(e => e.Value));
        }

        return Redirect("/");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            TempData["Errors"] = string.Join("\n", ex.Errors.SelectMany(e => e.Value));
        }

        return Redirect("/");
    }

    [HttpPost]
    public async Task<IActionResult> Complete(CompleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            TempData["Errors"] = string.Join("\n", ex.Errors.SelectMany(e => e.Value));
        }

        return Redirect("/");
    }
}
