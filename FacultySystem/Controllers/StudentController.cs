
using Faculty.Core.Fratures.Students.Commands.Models;
using FacultySystem.Bases;
using FacultySystem.Core.Features.Students.Commands.Modals;
using FacultySystem.Core.Features.Students.Commands.Models;
using FacultySystem.Core.Features.Students.Queries.Modals;
using FacultySystem.Core.Features.Students.Queries.Models;
using FacultySystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Faculty.API.Controllers
{
    [Route(Router.root)]
    [ApiController]
    public class StudentController : AppControllerBase
    {
        [HttpGet(Router.StudentRouring.List)]
        public async Task<IActionResult> GetAllStudents()
        {
            return NewResult(await Mediator.Send(new GetAllStudentsQuery()));
        }

        [HttpGet(Router.StudentRouring.PaginatedList)]
        public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentsPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.StudentRouring.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }
        [HttpPost(Router.StudentRouring.Create)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }
        [HttpPost(Router.StudentRouring.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }
        [HttpDelete(Router.StudentRouring.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
