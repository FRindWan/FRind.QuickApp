/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/21 星期四 11:04:40
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.NoteExample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Infrastructure
{
    /// <summary>
    /// <see cref="EFDbContext"/>
    /// </summary>
    public class EFDbContext:DbContext
    {
        public EFDbContext()
            : base("Server=(local);Database=QuickAppTest1;uid=sa;pwd=aaaa1111")
        { 
        
        }

        public DbSet<NoteInfo> NoteInfo { get; set; }
    }
}
