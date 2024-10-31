namespace Store.Domain.Utils;

/// <summary>
/// Classe de tratamento de resultados.
/// </summary>
/// <typeparam name="T">Tipo do objeto a ser retornado.</typeparam>
public class Result<T>
{
    /// <summary>
    /// Objeto a ser retornado.
    /// </summary>
    public T Obj { get; set; }
    
    /// <summary>
    /// Listagem de validações do objeto.
    /// </summary>
    public List<Validation> Validations { get; set; } = [];
    
    /// <summary>
    /// Método de verificação da integridade do objeto a partir das validações.
    /// </summary>
    /// <returns>Verificação de existencia de validações.</returns>
    public bool IsValid()
    {
        return !Validations.Any();
    }

    /// <summary>
    /// Método de adição de validações ao objeto.
    /// </summary>
    /// <param name="type">Tipo da validação q vai ser adicionada.</param>
    public void AddValidation(ValidationType type)
    {
        Validations.Add(new Validation { Type = type });
    }
}

/// <summary>
/// Classe de representação de validações.
/// </summary>
public class Validation
{
    /// <summary>
    /// Tipo da validação representada.
    /// </summary>
    public ValidationType Type { get; set; }
}

/// <summary>
/// Enumerador de validações.
/// </summary>
public enum ValidationType
{
    OrderListCannotBeEmpty,
    ProductOrderListCannotBeEmpty,
    ImpossibleToBoxOrder
}