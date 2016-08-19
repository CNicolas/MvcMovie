using Autofac;
using MvcMovie.DAL;
using MvcMovie.Models;
using MvcMovie.ViewModels;

namespace MvcMovie.App_Start
{
    public class DependeciesInjectionContainer
    {
        public static IContainer Container { get; private set; }

        public DependeciesInjectionContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MoviesRepository>().As<IMoviesRepository>().SingleInstance();

            builder.RegisterType<MoviesViewModel>();

            Container = builder.Build();
        }
    }
}