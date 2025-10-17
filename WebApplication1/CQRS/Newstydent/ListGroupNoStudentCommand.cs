using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;

namespace WebApplication1.CQRS.Newstydent
{
    public class ListGroupNoStudentCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public class ListGroupNoStudentCommandHandler :
            IRequestHandler<ListGroupNoStudentCommand, IEnumerable<GroupDTO>>
        {

            private readonly Db131025Context db;
            public ListGroupNoStudentCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<GroupDTO>> HandleAsync(ListGroupNoStudentCommand request,
                CancellationToken ct = default)
                  
            {
 
                return db.Groups.Include(s => s.Students).Where(g => g.Students.Count == 0).Select(g => new GroupDTO
                {
                    Id = g.Id,
                    Title = g.Title,
                    IdSpecial = g.IdSpecial
                }).ToList();
            }
        }


        }

    }

