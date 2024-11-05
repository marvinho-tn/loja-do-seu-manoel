using System.Text.Json.Serialization;

namespace Store.Api.Models;

/// <summary>
/// View de caixa com os produtos do pedido.
/// </summary>
public class BoxOrderViewModel
{
    /// <summary>
    /// Identificação da caixa.
    /// </summary>
    [JsonPropertyName("caixa_id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Listagem com os nomes dos produtos contidos na caixa.
    /// </summary>
    [JsonPropertyName("produtos")] 
    public IEnumerable<Guid> Products { get; set; } = [];
}