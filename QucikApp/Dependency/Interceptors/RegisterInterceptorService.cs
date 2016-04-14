/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:04:41
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency.Interceptors
{
    /// <summary>
    /// <see cref="RegisterInterceptorService"/>
    /// </summary>
    public class RegisterInterceptorService
    {
        public readonly static RegisterInterceptorService Instance;

        static RegisterInterceptorService()
        {
            Instance = new RegisterInterceptorService();
        }

        private IList<RegisterInterceptor> autofacRegisterInterceptors;

        private RegisterInterceptorService()
        {
            this.autofacRegisterInterceptors = new List<RegisterInterceptor>();
        }

        public void AddAutofacRegisterInterceptor(RegisterInterceptor autofacRegisterInterceptor)
        {
            if (autofacRegisterInterceptor == null)
            {
                return;
            }

            this.autofacRegisterInterceptors.Add(autofacRegisterInterceptor);
        }

        public void Register<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle>(IRegistrationBuilder<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle> registerBuilder,Type interfaceType,Type implType)
        {
            foreach (RegisterInterceptor autofacRegisterInterceptor in autofacRegisterInterceptors)
            {
                autofacRegisterInterceptor.Register(registerBuilder, interfaceType, implType);
            }
        }
    }
}
