using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;

namespace WebApplication1.CQRS.Newstydent
{
    public class ListStudentByGroupIndexCommand : IRequest<IEnumerable<StudentDTO>>
        {
        public string IndexGroup { get; set; }
        public class ListStudentByGroupIndexCommandHandler :
            IRequestHandler<ListStudentByGroupIndexCommand, IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public ListStudentByGroupIndexCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<StudentDTO>> HandleAsync(ListStudentByGroupIndexCommand request,
                CancellationToken ct = default)
            {

                return await db.Students.Where(s => s.IdGroup = s).Select(s =>
                new StudentDTO
                {
                    Id = s.Id,
                   
                }).ToListAsync();
            }

            Task<IEnumerable<StudentDTO>> IRequestHandler<ListStudentByGroupIndexCommand, IEnumerable<StudentDTO>>.HandleAsync(ListStudentByGroupIndexCommand request, CancellationToken ct)
            {
                throw new NotImplementedException();
            }
        }
    }
    }
