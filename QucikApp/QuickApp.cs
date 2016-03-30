﻿/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 17:19:43
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp
{
    /// <summary>
    /// <see cref="QuickApp"/>
    /// </summary>
    public class QuickApp:IQuickApp
    {
        private IConfigSource configSource;
        private IDependency dependency;

        public QuickApp()
        {
            this.dependency = DependencyFactory.GetDependency();
        }

        public IConfigSource ConfigSource
        {
            get { return this.configSource; }
        }

        public Dependency.IDependency DependencyContainer
        {
            get { return this.dependency; }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}