namespace Store.Domain.Utils;

public class Result<T>
{
    public T Obj { get; set; }
    public List<Validation> Validations { get; set; }
}

public class Validation
{
    public ValidationType ValidationType { get; set; }
}

public enum ValidationType
{
    
}