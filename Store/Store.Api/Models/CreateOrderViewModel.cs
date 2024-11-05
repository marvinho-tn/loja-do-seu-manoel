using System.Text.Json.Serialization;
using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Api.Models;

/// <summary>
/// View de processamento de pedidos.
/// </summary>
public class CreateOrderViewModel
{
    /// <summary>
    /// Identificação do pedido.
    /// </summary>
    [JsonPropertyName("pedido_id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Listagem de caixas do pedido.
    /// </summary>
    [JsonPropertyName("caixas")] 
    public IEnumerable<BoxOrderViewModel> Boxes { get; set; } = [];
}