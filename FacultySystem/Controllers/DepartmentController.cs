using FacultySystem.Bases;
using FacultySystem.Core.Features.Departments.Commands.Models;
using FacultySystem.Core.Features.Departments.Queries.Models;
using FacultySystem.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace FacultySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouring.List)]
        public async Task<IActionResult> GetDepartmentList()
        {
            return NewResult(await Mediator.Send(new GetDepartmentListQuery()));
        }
        [HttpGet(Router.DepartmentRouring.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetDepartmentByIdQuery(id)));
        }
        [HttpPost(Router.DepartmentRouring.Create)]
        public async Task<IActionResult> CreateDeoartment([FromBody] CreateDepartmentCommand request)
        {
            return NewResult(await Mediator.Send(request));
        }
        [HttpPost(Router.DepartmentRouring.Edit)]
        public async Task<IActionResult> EditDeoartment([FromBody] EditDepartmentCommand request)
        {
            return NewResult(await Mediator.Send(request));
        }
        [HttpDelete(Router.DepartmentRouring.Delete)]
        public async Task<IActionResult> DeleteDeoartment([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteDepartmentCommand(id)));
        }
    }
}
