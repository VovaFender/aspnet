using MvcApplication1.Global.Auth;
using MvcApplication1.Mappers;
using MvcApplication1.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MvcApplication1.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MvcApplication1.App_Start.NinjectWebCommon), "Stop")]

namespace MvcApplication1.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

//        for test only
        public interface IWeapon
        {
            string Kill();
        }
//        for test only
        public class Bazuka : IWeapon
        {
            public string Kill()
            {
                return "BIG BADABUM!";
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
//            for test
            kernel.Bind<IWeapon>().To<Bazuka>();

//            for users
            kernel.Bind<BookShopEntities>().ToMethod(e => new BookShopEntities());            
            kernel.Bind<IUserRepository>().To<UserRepository>().InTransientScope();

            kernel.Bind<IMapper>().To<CommonMapper>().InSingletonScope();

            kernel.Bind<IAuthentication>().To<Authentication>().InRequestScope();
        }        
    }
}
