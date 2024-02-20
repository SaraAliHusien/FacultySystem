using FacultySystem.Bases;
using FacultySystem.Core.Features.Instructors.Commands.Models;
using FacultySystem.Core.Features.Instructors.Queries.Models;
using FacultySystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace FacultySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : AppControllerBase
    {
        [HttpGet(Router.InstructorRouring.List)]
        public async Task<IActionResult> GetAllInstructor()
        {
            return NewResult(await Mediator.Send(new GetInstructorListQuery()));
        }

        [HttpGet(Router.InstructorRouring.GetById)]
        public async Task<IActionResult> GetInstructorById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetInstructorByIdQuery(id)));
        }
        [HttpPost(Router.InstructorRouring.Create)]
        public async Task<IActionResult> Create([FromBody] CreateInstructorCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }
        [HttpPost(Router.InstructorRouring.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditInstructorCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }
        [HttpDelete(Router.InstructorRouring.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteInstructorCommand(id)));
        }
    }
}
