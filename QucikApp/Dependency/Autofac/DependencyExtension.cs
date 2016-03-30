/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:37:54
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency.Autofac
{
    /// <summary>
    /// <see cref="DependencyExtension"/>
    /// </summary>
    public static class DependencyExtension
    {
        public static void SetLifeTime<TLimit, TReflectionActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registrationBuilder, DependencyLifeTime lifeTime)
        {
            if (lifeTime == DependencyLifeTime.Singleton)
            {
                registrationBuilder.SingleInstance();
            }
        }
    }
}
