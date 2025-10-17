using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.CQRS.Newstydent;
using WebApplication1.DB;

namespace WebApplication6.cqrs.Student
{
    public class ListStudentByGroupIndexCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public int IndexGroup { get; set; }
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

                return await db.Students.Where(s => s.Id == request.IndexGroup).Select(s =>
                new StudentDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,

                    LastName = s.LastName,

                    Phone = s.Phone,

                    Gender = s.Gender,

                    IdGroup = s.IdGroup,
                }).ToListAsync();
            }
        }
    }
}

