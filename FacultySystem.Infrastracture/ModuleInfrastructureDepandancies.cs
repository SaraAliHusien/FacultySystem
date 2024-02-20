using Faculty.Infrastructure.Repositories;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FacultySystem.Infrastracture
{
    public static class ModuleInfrastructureDepandancies
    {
        public static IServiceCollection AddInfrastructureDepandancies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient<IInstructorRepo, InstructorRepo>();
            services.AddTransient<ISubjectRepo, SubjectRepo>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}