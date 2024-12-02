using ToDoApp.Application.Common.Interfaces;

namespace ToDoApp.Application.TodoItems.Commands.CompleteTodoItem;

public class CompleteTodoItemCommandValidator : AbstractValidator<CompleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public CompleteTodoItemCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) => await _context.TodoItems.AnyAsync(t => t.Id == id, cancellationToken))
            .WithMessage("Item for completion is not found.");
    }
}
