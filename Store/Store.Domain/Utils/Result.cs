namespace Store.Domain.Utils;

public class Result<T>
{
    public T Obj { get; set; }
    public List<Validation> Validations { get; set; } = [];
    
    public bool IsValid()
    {
        return Validations.Any();
    }
}

public class Validation
{
    public ValidationType Type { get; set; }
}

public enum ValidationType
{
    
}