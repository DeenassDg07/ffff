using MyMediator.Interfaces;
using MyMediator.Types;
//using WebApplication1.DB;

namespace WebApplication1.CQRS.CommandList
{
    public class AddMaterialCommand : IRequest
    {
        public class MaterialDTO
        {
       // public class AddMaterialCommandHandler 
           // : IRequestHandler <AddMaterialCommand, Unit>
       // {
            //private readonly DemkaContext db;
           // public AddMaterialCommandHandler(DemkaContext db)
            //{
              ///  this.db = db;
            }
            public async Task<Unit> HandleAsync(
                AddMaterialCommand request, CancellationToken ct = default)
            {
                    //db.Materials.Add(new Material
                    //{
                    //    Title = request.Title,
                    //});
                    
                    return Unit.Value;
            }
        }
        }
       
    //}
    
//}

