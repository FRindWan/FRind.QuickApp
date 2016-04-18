/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:54:46
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Config.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Config
{
    /// <summary>
    /// <see cref="ConfigSource"/>
    /// </summary>
    public class ConfigSource:IConfigSource
    {
        public readonly static IConfigSource Instance;

        static ConfigSource()
        { 
            Instance=new ConfigSource();
        }

        private IDependencyConfigSource dependencyConfigSource;

        public ConfigSource()
        {
            this.dependencyConfigSource = new DependencyConfigSource();
        }

        public IDependencyConfigSource DependencyConfigSource { get { return this.dependencyConfigSource; } }
    }
}
