
public class Processo
{
    public int Id { get; set; }
    public bool Excepcional { get; set; }
    public int? VaraId { get; set; }
    public Vara Vara { get; set; }
    public int ForoId { get; set; }
    public Foro Foro { get; set; }
}

public class Vara
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class Foro
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class ValidationItem
{
    public ValidationItem(string error, string message)
    {
        Error = error;
        Message = message;
    }

    public object Arguments { get; set; }
    public string Error { get; set; }
    public string Location { get; set; }
    public string Message { get; set; }
}


