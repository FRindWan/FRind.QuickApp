/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:04:41
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Autofac.Builder;
using QuickApp.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;

namespace QuickApp.Dependency.Autofac
{
    /// <summary>
    /// <see cref="RegisterInterceptorService"/>
    /// </summary>
    public class RegisterInterceptorService
    {
        public readonly static RegisterInterceptorService Instance;

        static RegisterInterceptorService()
        {
            Instance = new RegisterInterceptorService(ConfigSource.Instance);
        }

        private IList<RegisterInterceptor> autofacRegisterInterceptors;
        private IConfigSource configSource;

        private RegisterInterceptorService(IConfigSource configSource)
        {
            this.autofacRegisterInterceptors = new List<RegisterInterceptor>();
            this.configSource = configSource;
        }

        public void AddAutofacRegisterInterceptor(RegisterInterceptor autofacRegisterInterceptor)
        {
            if (autofacRegisterInterceptor == null)
            {
                return;
            }

            this.autofacRegisterInterceptors.Add(autofacRegisterInterceptor);
        }

        public void Register<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle>(IRegistrationBuilder<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle> registerBuilder, Type implType, Type interfaceType=null)
        {
            if (this.configSource.DependencyConfigSource.EnableInterceptor)
            {
                foreach (RegisterInterceptor autofacRegisterInterceptor in autofacRegisterInterceptors)
                {
                    autofacRegisterInterceptor.Register(registerBuilder, interfaceType, implType);
                }
            }
        }
    }
}
