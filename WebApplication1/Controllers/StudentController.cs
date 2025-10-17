using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using System.Reflection;
using WebApplication1.CQRS.CommandList;
using WebApplication1.CQRS.Newstydent;
using WebApplication6.cqrs.Student;
//using WebApplication1.DB;
//https://localhost:7203/api/Student/ListGender/1
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Mediator mediator;
        public StudentController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("ListStudent/{id}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> ListStudent(int id)
        {
            // 1. экземпляр команды 
            var command = new ListStudentByGroupIndexCommand { IndexGroup = id };
            // 2. отправили команду на обработку в медиатор
            // 3. медиатор нашел обработчик, передал туда команду, получил результат
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
        [HttpGet("ListGender/{gender}")]
        public async Task<ActionResult<GenderDTO>> ListGender(int gender)
        {
            var command = new ListStudentGenderMenWomenCommand { IndexGroup = gender };
            var result = await mediator.SendAsync(command);

            return Ok(result);
        }
        [HttpGet("SrudentGroupNull/{groupNull}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> SrudentGroupNull(int groupNull)
        {
            var command = new ListStudentGroupNullCommand { IndexGroup = groupNull };
            var result = await mediator.SendAsync(command);

            return Ok(result);
        }
    }
}