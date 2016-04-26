using QuickApp.Commands;
using QuickApp.Common.Test.Command;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Data.Infrastructure.MSSqlerver;
using QuickApp.Dependency;
using QuickApp.NoteExample.Infrastructure;
using QuickApp.Test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            DependencyInitializeService.AddDependencyInitialize(new QuickAppTestDependencyInitialize());

            IQuickApp app = new DefaultQuickApp();
            app.ConfigSource.EventConfigSource.SetAssembly(Assembly.Load("QuickApp.Common.Test"));
            app.ConfigSource.CommandConfigSource.SetAssembly(Assembly.Load("QuickApp.Common.Test"));

            app.Initialize();

            CommandExecuter commandExecuter = app.DependencyContainer.Resolver<CommandExecuter>();
            commandExecuter.ExecuteAsync(new AddPersonCommand()
            {
                PersonInfo = new PersonInfo()
                {
                    ID = Guid.NewGuid(),
                    Age = 22,
                    UserName = "FRind"
                }
            });

            PersonInfo personInfo=(PersonInfo)commandExecuter.Execute(new GetPersonCommand("FRind"));

            Console.WriteLine(personInfo.UserName+"  "+personInfo.Age);

            IList<PersonInfo> personInfoList = new List<PersonInfo>();
            int i = 0;
            while (i < 10000)
            {
                personInfoList.Add(new PersonInfo() { ID = Guid.NewGuid(), Age = i, UserName = "FRind" + i });
                i++;
            }

            IList<String> personInfoSqlList = new List<String>();
            StringBuilder personInfoSqlBuilder = new StringBuilder();
            int j = 0;
            while (j < 10000)
            {
                //personInfoSqlList.Add(String.Format("insert into personinfoes (id,username,age) values ('{0}','{1}',{2});", Guid.NewGuid(), "FRind" + j, j));

                personInfoSqlBuilder.Append(String.Format("insert into personinfoes (id,username,age) values ('{0}','{1}',{2});", Guid.NewGuid(), "FRind" + j, j));
                j++;
            }


            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //commandExecuter.Execute(new AddPersonListCommand(personInfoList));
            //stopwatch.Stop();

            //Console.WriteLine("Insert 10000 PersonInfo use time : " + stopwatch.Elapsed.TotalMilliseconds+" (ms)");

            MSSqlDbFactory factory = new MSSqlDbFactory("Server=(local);DataBase=QuickAppTest1;uid=sa;pwd=aaaa1111!");
             Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
           foreach(String sql in personInfoSqlList)
           {
               factory.ExecuteSql(personInfoSqlBuilder.ToString());
           }
            stopwatch2.Stop();
            Console.WriteLine("Sql: Insert 10000 PersonInfo use time : " + stopwatch2.Elapsed.TotalMilliseconds+" (ms)");

            Console.Read();
        }
    }
}
