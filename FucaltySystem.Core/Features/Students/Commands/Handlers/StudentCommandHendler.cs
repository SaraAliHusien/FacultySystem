using AutoMapper;
using Faculty.Core.Fratures.Students.Commands.Models;
using Faculty.Core.Fratures.Students.Queries.Results;
using Faculty.Core.Wrappers;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Students.Commands.Modals;
using FacultySystem.Core.Features.Students.Commands.Models;
using FacultySystem.Core.Features.Students.Queries.Models;
using FacultySystem.Core.Wrappers;
using FacultySystem.Data.Enteties;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using MediatR;
using System.Globalization;
using System.Linq.Expressions;

namespace Faculty.Core.Fratures.Students.Commands.Handlers
{
    public class StudentCommandHendler
    : ResponseHandler, IRequestHandler<CreateStudentCommand, ResponseBase<string>>
     , IRequestHandler<EditStudentCommand, ResponseBase<string>>
    , IRequestHandler<DeleteStudentCommand, ResponseBase<string>>
    , IRequestHandler<GetStudentsPaginatedListQuery, PaginatedResult<GetStudentsPaginatedListResponse>>
    {

        #region fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        //private readonly IStringLocalizer<SharedResource> _localizerString;

        #endregion
        #region ctros
        public StudentCommandHendler(IStudentService studentService, IMapper mapper
            //, IStringLocalizer<SharedResource> localizerString
            )
        //: base(localizerString)
        {
            _studentService = studentService;
            _mapper = mapper;
            //_localizerString = localizerString;
        }
        public Task<PaginatedResult<GetStudentsPaginatedListResponse>> Handle(GetStudentsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            Expression<Func<Student, GetStudentsPaginatedListResponse>> expression = e => new GetStudentsPaginatedListResponse()
            {
                StudentId = e.StudentId,
                StudentName = e.StudentName,
                Address = e.Address,
                Phone = e.Phone,
                DepartmentName = e.Department.DepartmentName,

            };
            var studentsQuarable = _studentService.GetStudentQuarable(request.ordering, request.search);
            var paginatedList = studentsQuarable.Select(expression).ToPaginatedListAsync(request.pageSize, request.pageNum);
            return paginatedList;
        }
        public async Task<ResponseBase<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var newStudent = _mapper.Map<Student>(request);
            await _studentService.CreateNewStudent(newStudent);
            //_localizerString[SharedResourcesKeys.Created]
            return Created("Created");
        }

        public async Task<ResponseBase<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check if id is existing or no
            var student = await _studentService.GetByIdWithoutDeptAsync(request.StId);
            if (student == null)
                //_localizerString[SharedResourcesKeys.NotFound]
                return NotFound<string>("NotFound");
            //mapping request=> student 
            var newStudent = _mapper.Map(request, student);
            // call edit service
            var result = await _studentService.EditAsync(newStudent);
            // return response
            if (result == "success")
                //_localizerString[SharedResourcesKeys.Success]
                return Success<string>("Success");
            return BadRequest<string>();
        }

        public async Task<ResponseBase<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check if id is existing or no
            var student = await _studentService.GetByIdWithoutDeptAsync(request.Id);
            if (student == null)
                return NotFound<string>("Not Found");

            // call delete service
            var result = await _studentService.DeleteAsync(student);
            // return response
            if (result == ResponseTypesMatching.DeletedResponse)
                return Deleted<string>(ResponseTypesMatching.DeletedResponse);
            if (result == ResponseTypesMatching.FailExcuteService)
                return Failed<string>("Cann't Delete this Student becouse has relations Departments or instructors or subjects");
            return BadRequest<string>();
        }


        #endregion
    }
}
