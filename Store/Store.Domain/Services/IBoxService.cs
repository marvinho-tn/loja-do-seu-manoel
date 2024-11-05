using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Services;

public interface IBoxService
{
    Result<IEnumerable<Box>> GetAllBoxes();
}