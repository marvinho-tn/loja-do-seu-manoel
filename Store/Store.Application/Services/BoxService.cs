using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Services;
using Store.Domain.Utils;

namespace Store.Application.Services;

public class BoxService(IBoxRepository boxRepository) : IBoxService
{
    public Result<IEnumerable<Box>> GetAllBoxes()
    {
        var boxes = boxRepository.GetAllBoxesWithProducts();
        var result = new Result<IEnumerable<Box>>(boxes);

        return result;
    }
}