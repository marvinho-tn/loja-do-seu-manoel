using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Configuration.Database;

namespace Store.Infra.Repositories;

/// <summary>
/// Classe de repositório de caixas.
/// </summary>
public class BoxRepository(StoreDbContext context) : IBoxRepository
{
    /// <summary>
    /// Método de busca de moldes de caixas disponíveis.
    /// </summary>
    /// <returns>Listagem com moldes de caixa.</returns>
    public IEnumerable<BoxMold> GetAllTypesOfBoxes()
    {
        return context.Set<BoxMold>().ToList();
    }

    public IEnumerable<Box> GetAllBoxesWithProducts()
    {
        return context
            .Set<Box>()
            .Include(box => box.Products)
            .ToList();
    }
}