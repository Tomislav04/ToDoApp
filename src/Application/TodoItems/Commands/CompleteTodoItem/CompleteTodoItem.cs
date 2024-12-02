using ToDoApp.Application.Common.Interfaces;

namespace ToDoApp.Application.TodoItems.Commands.CompleteTodoItem;

public record CompleteTodoItemCommand : IRequest<Unit>
{
    public int Id { get; init; }
}

public class CompleteTodoItemCommandHandler : IRequestHandler<CompleteTodoItemCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public CompleteTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(CompleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _context.TodoItems.FindAsync(request.Id);

        if (todoItem == null)
        {
            throw new Exception("Item not found.");
        }

        todoItem.Done = true;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
