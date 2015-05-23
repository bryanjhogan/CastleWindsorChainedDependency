using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorChainedDependency.Contracts;
using CastleWindsorChainedDependency.Controllers;
using CastleWindsorChainedDependency.Services.Message;

namespace CastleWindsorChainedDependency.Installers
{
    public class ContractInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                 Component.For<IMessageLoader>().ImplementedBy<MessageLoaderDatabase>()
                ,Component.For<IMessageLoader>().ImplementedBy<MessageLoaderFile>()
                
                ,Component.For<IMessageOfTheDayService>().ImplementedBy<MessageOfTheDayServiceDatabase>()
                    .DependsOn(Dependency.OnComponent<IMessageLoader, MessageLoaderDatabase>())
            
                ,Component.For<IMessageOfTheDayService>().ImplementedBy<MessageOfTheDayServiceFile>()
                    .DependsOn(Dependency.OnComponent<IMessageLoader, MessageLoaderFile>())
                
                ,Component.For<MessageOfTheDayController>().LifestyleTransient()
                    .DependsOn(Dependency.OnComponent<IMessageOfTheDayService, MessageOfTheDayServiceFile>())
            );


            // ***** This is another way of doing the same with some named instances ***** 
            // ***************************************************************************
            //container.Register(
            //     Component.For<IMessageLoader>().ImplementedBy<MessageLoaderDatabase>()
            //    ,Component.For<IMessageLoader>().ImplementedBy<MessageLoaderFile>()
                
            //    ,Component.For<IMessageOfTheDayService>().ImplementedBy<MessageOfTheDayServiceDatabase>().Named("ServiceDatabase")
            //        .DependsOn(Dependency.OnComponent<IMessageLoader, MessageLoaderDatabase>())

            //    ,Component.For<IMessageOfTheDayService>().ImplementedBy<MessageOfTheDayServiceFile>().Named("ServiceFile")
            //        .DependsOn(Dependency.OnComponent<IMessageLoader, MessageLoaderFile>())
                
            //    ,Component.For<MessageOfTheDayController>().LifestyleTransient()
            //        .DependsOn(ServiceOverride.ForKey<IMessageOfTheDayService>().Eq("ServiceDatabase"))
            //);



            // ***** This is another way of doing the same with many named instances ***** 
            // ***************************************************************************
            //container.Register(
            //     Component.For<IMessageLoader>().ImplementedBy<MessageLoaderDatabase>().Named("LoaderDatabase")
            //    ,Component.For<IMessageLoader>().ImplementedBy<MessageLoaderFile>().Named("LoaderFile")
                
            //    ,Component.For<IMessageOfTheDayService>().ImplementedBy<MessageOfTheDayServiceDatabase>().Named("ServiceDatabase")
            //        .DependsOn(ServiceOverride.ForKey<IMessageLoader>().Eq("LoaderDatabase"))
                
            //    ,Component.For<IMessageOfTheDayService>().ImplementedBy<MessageOfTheDayServiceFile>().Named("ServiceFile")
            //        .DependsOn(ServiceOverride.ForKey<IMessageLoader>().Eq("LoaderFile"))
                
            //    ,Component.For<MessageOfTheDayController>().LifestyleTransient()
            //        .DependsOn(ServiceOverride.ForKey<IMessageOfTheDayService>().Eq("ServiceDatabase"))
            //);
        }
    }
}