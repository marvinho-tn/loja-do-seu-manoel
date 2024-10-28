using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IBoxRepository
{
    IEnumerable<BoxMold> GetAllTypesOfBoxes();
}