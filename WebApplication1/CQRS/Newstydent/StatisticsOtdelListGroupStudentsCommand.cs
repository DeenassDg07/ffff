using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;

namespace WebApplication1.CQRS.Newstydent
{
    public class StatisticsOtdelListGroupStudentsCommand : IRequest<IEnumerable<GroupDTO>>
    {

        public class StatisticsOtdelListGroupStudentsCommandHandler :
            IRequestHandler<StatisticsOtdelListGroupStudentsCommand, IEnumerable<GroupDTO>>
        {

            private readonly Db131025Context db;
            public StatisticsOtdelListGroupStudentsCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<GroupDTO>> HandleAsync(StatisticsOtdelListGroupStudentsCommand request,
                CancellationToken ct = default)
            {
                    List <GroupDTO> group =  await db.Groups.Select(s => 
                    new GroupDTO
                    {
                    Id =s.Id,
                    Title = s.Title,
                    IdSpecial = s.IdSpecial,
                    }).ToListAsync();
            }
            //public int Id { get; set; }

            //public string? Title { get; set; }

            //public int? IdSpecial { get; set; }
            //public int CountGroup { get; set; }
            //GenderDTO genderDTO = new GenderDTO();
            //genderDTO.Men = students.Count(s => s.Gender == 1);
            //    genderDTO.Woomen = students.Count(s => s.Gender == 0);

        }
    }

}
