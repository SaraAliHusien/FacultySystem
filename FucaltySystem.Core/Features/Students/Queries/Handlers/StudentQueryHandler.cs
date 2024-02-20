

using AutoMapper;

using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Students.Queries.Modals;
using FacultySystem.Core.Features.Students.Queries.Results;
using FacultySystem.Service.Abstruction;
using MediatR;


namespace FacultySystem.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetAllStudentsQuery, ResponseBase<List<GetStudentWithDeptName>>>
    , IRequestHandler<GetStudentByIdQuery, ResponseBase<GetStudentWithDeptName>>
    {
        #region fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        //private readonly IStringLocalizer<SharedResource> _localizer;
        #endregion
        #region ctros
        //, IMapper mapper, IStringLocalizer<SharedResource> localizer) : base(localizer)
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
            //_localizer = localizer;
        }
        #endregion
        public async Task<ResponseBase<List<GetStudentWithDeptName>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetAllAsync();
            List<GetStudentWithDeptName> studentListMapper = _mapper.Map<List<GetStudentWithDeptName>>(studentList);
            //foreach (var student in studentList)
            //{
            //    var hh = new GetStudentWithDeptName()
            //    {
            //        StudentId = student.StudentId,
            //        StudentName = student.StudentName,
            //        Address = student.Address,
            //        Phone = student.Phone,
            //        DepartmentName = student.Department.DepartmentName

            //    };
            //    studentListMapper.Add(hh);
            //}


            return Success(studentListMapper);
        }

        public async Task<ResponseBase<GetStudentWithDeptName>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return BadRequest<GetStudentWithDeptName>();

            var student = await _studentService.GetByIdAsync(request.Id);
            if (student is null)
                //_localizer[SharedResourcesKeys.NotFound]
                return NotFound<GetStudentWithDeptName>("NotFound");
            var studentMapper = _mapper.Map<GetStudentWithDeptName>(student);
            /*_localizer[SharedResourcesKeys.Success])*/
            return Success(studentMapper, message: "");
        }
    }
}
