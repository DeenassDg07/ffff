using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;

namespace WebApplication1.CQRS.Newstydent
{
        public class ListStudentGenderMenWomenCommand : IRequest<GenderDTO>
        {

            public int IndexGroup { get; set; }
            public class ListStudentGenderMenWomenCommandHandler :
                IRequestHandler<ListStudentGenderMenWomenCommand, GenderDTO>
            {

                private readonly Db131025Context db;
                public ListStudentGenderMenWomenCommandHandler(Db131025Context db)
                {
                    this.db = db;
                }
                public async Task<GenderDTO> HandleAsync(ListStudentGenderMenWomenCommand request,
                    CancellationToken ct = default)
                {

                   List<Student> students = await db.Students.Where(s => s.IdGroup == request.IndexGroup).ToListAsync();
                   GenderDTO genderDTO = new GenderDTO();
                    genderDTO.Men = students.Count(s => s.Gender == 1);
                genderDTO.Woomen = students.Count(s => s.Gender == 0);
                return genderDTO ;
            }

        }
        }
    
}
