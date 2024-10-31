using Store.Domain.Entities;

namespace Store.Domain.Repositories;

/// <summary>
/// Interface de repositório de caixas.
/// </summary>
public interface IBoxRepository
{
    /// <summary>
    /// Método de busca de moldes de caixas disponíveis.
    /// </summary>
    /// <returns>Listagem com moldes de caixa.</returns>
    IEnumerable<BoxMold> GetAllTypesOfBoxes();
}