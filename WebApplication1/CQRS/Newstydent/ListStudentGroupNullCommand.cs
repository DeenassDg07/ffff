using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;

namespace WebApplication1.CQRS.Newstydent
{
    public class ListStudentGroupNullCommand : IRequest<IEnumerable<StudentDTO>>
    {

        public int IndexGroup { get; set; }
        public class ListStudentGroupNullCommandHandler :
            IRequestHandler<ListStudentGroupNullCommand, IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public ListStudentGroupNullCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<StudentDTO>> HandleAsync(ListStudentGroupNullCommand request,
                CancellationToken ct = default)
            {

                return await db.Students.Where(s => s.IdGroup == null).Select(s =>
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

