/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:54:37
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Domain.Reposities
{
    /// <summary>
    /// <see cref="EFDbContext"/>
    /// </summary>
    public class EFDbContext:DbContext
    {
        public EFDbContext()
            : base("Server=(local);DataBase=QuickAppTest1;uid=sa;pwd=aaaa1111!")
        { 
        
        }

        public DbSet<PersonInfo> PersonInfo { get; set; }
    }
}
