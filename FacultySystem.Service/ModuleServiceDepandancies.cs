using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace FacultySystem.Service
{
    public static class ModuleServiceDepandancies
    {
        public static IServiceCollection AddServiceDepandancies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();

            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<ISubjectService, SubjectService>();


            return services;

        }
    }

}
