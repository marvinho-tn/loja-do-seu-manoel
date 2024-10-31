using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Infra.Repositories;

/// <summary>
/// Classe de repositório de caixas.
/// </summary>
public class BoxRepository : IBoxRepository
{
    /// <summary>
    /// Método de busca de moldes de caixas disponíveis.
    /// </summary>
    /// <returns>Listagem com moldes de caixa.</returns>
    public IEnumerable<BoxMold> GetAllTypesOfBoxes()
    {
        return new List<BoxMold>
        {
            new BoxMold
            {
                Height = 30,
                Width = 40,
                Length = 80,
            },
            new BoxMold
            {
                Height = 80,
                Width = 50,
                Length = 40,
            },
            new BoxMold
            {
                Height = 50,
                Width = 80,
                Length = 60,
            },
        };
    }
}