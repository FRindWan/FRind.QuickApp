/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 15:53:57
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Config;
using QuickApp.Dependency;
using QuickApp.Query.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query
{
    /// <summary>
    /// <see cref="InterpreterDependencyInitialize"/>
    /// </summary>
    public class InterpreterDependencyInitialize:DependencyInitialize
    {
        public override void InitializeInterceptor(Dependency.Autofac.RegisterInterceptorService registerInterceptorService)
        {
            
        }

        public override void InitializeDependency(IDependencyRegister dependency)
        {
            switch (ConfigSource.Instance.RepositoryConfigSource.DbType)
            { 
                case Infrastructure.DataBaseType.MSSQLSERVER:
                    dependency.Register<IInterpreter, MSSqlServerInterpreter>();
                    break;
            }
        }
    }
}
