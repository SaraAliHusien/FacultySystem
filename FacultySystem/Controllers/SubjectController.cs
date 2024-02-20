using FacultySystem.Bases;
using FacultySystem.Core.Features.Subjects.Commands.Models;
using FacultySystem.Core.Features.Subjects.Queries.Models;
using FacultySystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace FacultySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : AppControllerBase
    {
        [HttpGet(Router.SubjectRouring.List)]
        public async Task<IActionResult> GetAllSubjects()
        {
            return NewResult(await Mediator.Send(new GetSubjectListQuery()));
        }

        [HttpGet(Router.SubjectRouring.GetById)]
        public async Task<IActionResult> GetSubjectById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetSubjectByIdQuery(id)));
        }
        [HttpPost(Router.SubjectRouring.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSubjectCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }
        [HttpPost(Router.SubjectRouring.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditSubjectCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }
        [HttpDelete(Router.SubjectRouring.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteSubjectCommand(id)));
        }
    }
}
