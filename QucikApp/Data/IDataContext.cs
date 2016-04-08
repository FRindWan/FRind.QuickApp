/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/5 星期二 17:50:29
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Data
{
    /// <summary>
    /// <see cref="IDataContext"/>
    /// </summary>
    public interface IDataContext
    {
        String DataConnectString { get; }

        void Add<T>(T t);

        void Add(Object obj);

        void Update<T>(T t);

        void Update(Object obj);

        void Delete<T>(T t);

        void Delete(Object obj);
    }
}
