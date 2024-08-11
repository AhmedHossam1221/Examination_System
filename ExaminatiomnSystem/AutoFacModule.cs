using Autofac;
using ExaminatiomnSystem.Data;
using ExaminatiomnSystem.Repositories;
using ExaminatiomnSystem.Services.Instractours;
using ExaminatiomnSystem.Services.Student;

namespace ExaminatiomnSystem
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IInstractourService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IStudentService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
