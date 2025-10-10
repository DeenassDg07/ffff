using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;

namespace WebApplication1.CQRS.CommandList
{
    public class GetListMaterialCommand : IRequest<IEnumerable<MaterialDTO>>
    {
        public class GetListGenderCommandHandler :
            IRequestHandler<GetListMaterialCommand, IEnumerable<MaterialDTO>>
        {

            private readonly DemkaContext db;
            public GetListGenderCommandHandler(DemkaContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<MaterialDTO>> HandleAsync(GetListMaterialCommand request,
                CancellationToken ct = default)
            {

                return await db.Materials.Include(s => s.Metrica).Include(s => s.MaterialType).Select(s =>
                new MaterialDTO
                {
                    Id = s.Id,
                    MaterialTypeId = s.MaterialTypeId,
                    MaterialType = s.MaterialType.Title,
                    Metrica = s.Metrica.Title,
                    MetricaId = s.MetricaId,
                    Title = s.Title,
                    MinCount = s.MinCount,
                    PackCount = s.PackCount,
                    Price = s.Price,
                    StorageCount = s.StorageCount,
                }).ToListAsync();

            }
        }
    }
}
