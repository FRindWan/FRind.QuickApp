/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:54:46
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Config;
using QuickApp.Common.Config.impl;
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

        private readonly IDependencyConfigSource dependencyConfigSource;
        private readonly IEventConfigSource eventConfigSource;
        private readonly ICommandConfigSource commandConfigSource;

        private ConfigSource()
        {
            this.dependencyConfigSource = new DependencyConfigSource();
            this.eventConfigSource = new EventConfigSource();
            this.commandConfigSource = new CommandConfigSource();
        }

        public IDependencyConfigSource DependencyConfigSource { get { return this.dependencyConfigSource; } }


        public IEventConfigSource EventConfigSource { get { return this.eventConfigSource; } }


        public Common.Config.ICommandConfigSource CommandConfigSource { get { return this.commandConfigSource; } }
    }
}
