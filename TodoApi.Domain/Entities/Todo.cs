namespace TodoApi.Domain.Entities;

public class Todo
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsComplete { get; private set; }

    public Todo(string title)
    {
        ValidateTodoTitle(title);

        Id = Guid.NewGuid();
        Title = title;
    }

    private void ValidateTodoTitle(string title)
    {
        if (title.Length == 0 || title == null)
            throw new InvalidDataException("Informe sua tarefa");
    }

    public void CompleteTask()
    {
        IsComplete = true;
    }
}
