using Store.Domain.Entities;

namespace Store.Domain.Repositories.Implementations;

public class BoxRepository : IBoxRepository
{
    public async Task<IEnumerable<BoxMold>> GetAllTypesOfBoxesAsync()
    {
        return await Task.Run(() => new List<BoxMold>
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
        });
    }
}