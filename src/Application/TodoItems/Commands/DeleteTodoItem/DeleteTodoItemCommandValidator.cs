using ToDoApp.Application.Common.Interfaces;

namespace ToDoApp.Application.TodoItems.Commands.DeleteTodoItem;

public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoItemCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) => await _context.TodoItems.AnyAsync(t => t.Id == id, cancellationToken))
            .WithMessage("Item for deletion is not found..");
    }
}
