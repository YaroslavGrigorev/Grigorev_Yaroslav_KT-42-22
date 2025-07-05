using Project_practicum.Interfaces.DepartmentInterfaces;
using Project_practicum.Interfaces.DisciplineInterfaces;
using Project_practicum.Interfaces.DisciplinesByDepartmentHeadInterfaces;
using Project_practicum.Interfaces.LoadInterfaces;
using Project_practicum.Interfaces.TeacherInterfaces;
using System.ComponentModel.Design;
namespace Project_practicum.ServiceExtencions
{
    public static class ServiceExtencions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ILoadService, LoadService>();
            services.AddScoped<IDisciplinesByDepartmentHeadService, DisciplinesByDepartmentHeadService>();

            return services;
        }
    }
}
