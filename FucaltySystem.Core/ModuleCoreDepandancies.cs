using FacultySystem.Core.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FucaltySystem.Core
{
    public static class ModuleCoreDepandancies
    {
        public static IServiceCollection AddCoreDepandancies(this IServiceCollection services)
        {
            //configuration mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //configration mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}