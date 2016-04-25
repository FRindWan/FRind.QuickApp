using QuickApp.NoteExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuickApp app = new DefaultQuickApp();
            app.ConfigSource.CommandConfigSource.SetAssembly(Assembly.GetExecutingAssembly());
            app.DependencyContainer.Register<EFDbContext>();
            app.DependencyContainer.Register(Assembly.GetExecutingAssembly());

            app.Initialize();
        }
    }
}
