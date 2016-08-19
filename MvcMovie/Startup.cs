using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using MvcMovie.DAL;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(MvcMovie.Startup))]
namespace MvcMovie
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = BuildDepenciesInjectionContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseStaticFiles();

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        private IContainer BuildDepenciesInjectionContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieActorRepository>().As<IMovieActorRepository>().SingleInstance();
            builder.RegisterType<MoviesRepository>().As<IMoviesRepository>().SingleInstance();
            builder.RegisterType<ActorsRepository>().As<IActorsRepository>().SingleInstance();

            builder.RegisterControllers(typeof(Startup).Assembly);

            return builder.Build();
        }
    }
}
