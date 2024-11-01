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
    public List<Validation> Errors { get; set; } = [];
    
    /// <summary>
    /// Método de verificação da integridade do objeto a partir das validações.
    /// </summary>
    /// <returns>Verificação de existencia de validações.</returns>
    public bool IsValid()
    {
        return !Errors.Any();
    }

    /// <summary>
    /// Método de adição de validações ao objeto.
    /// </summary>
    /// <param name="type">Tipo da validação q vai ser adicionada.</param>
    public void AddValidation(ValidationType type)
    {
        Errors.Add(new Validation(type));
    }
}

/// <summary>
/// Classe de representação de validações.
/// </summary>
public class Validation(ValidationType type)
{
    /// <summary>
    /// Tipo da validação representada.
    /// </summary>
    public ValidationType Type { get; set; } = type;
}

/// <summary>
/// Enumerador de validações.
/// </summary>
public enum ValidationType
{
    //Unprocessable Entity
    OrderListCannotBeEmpty = 422001,
    ProductOrderListCannotBeEmpty = 422002,
    ImpossibleToBoxOrder = 422003,
    EmptyBoxMoldList = 422004,
    
    //Internal Server Error
    UnexpectedError = 500001,
}