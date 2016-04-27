using QuickApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickApp.NoteExample.Mvc
{
    public class MSSqlDbContext:SqlDbContext
    {
        public MSSqlDbContext()
            : base("Server=(local);DataBase=QuickAppTest1;uid=sa;pwd=aaaa1111!")
        { }
    }
}