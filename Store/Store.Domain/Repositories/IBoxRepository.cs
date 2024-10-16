using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IBoxRepository
{
    Task<IEnumerable<BoxMold>> GetAllTypesOfBoxesAsync();
}