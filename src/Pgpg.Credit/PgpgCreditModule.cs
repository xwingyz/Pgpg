using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Pgpg.Credit.Service;

namespace Pgpg.Credit
{
    [DependsOn(
       typeof(AbpAutoMapperModule))]
    public class PgpgCreditModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(
                Component.For<ICalculator, DisposableCalculator>()
                    .LifestyleTransient()
                    .Named(DisposableCalculator.CalculatorName.ToString()));

            IocManager.IocContainer.Register(
                Component.For<ICalculator, AfterTheFirstInterestCalculator>()
                    .LifestyleTransient()
                    .Named(AfterTheFirstInterestCalculator.CalculatorName.ToString()));

            IocManager.IocContainer.Register(
              Component.For<ICalculator, AverageCapitalPlusInterestCalculator>()
                  .LifestyleTransient()
                  .Named(AverageCapitalPlusInterestCalculator.CalculatorName.ToString()));
        }
    }

}
