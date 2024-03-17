namespace TodoApi.Domain.Errors;

public class TodosNotFoundException : Exception
{
    public TodosNotFoundException()
    {
    }

    public TodosNotFoundException(string message) : base(message)
    {
    }

    public TodosNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
