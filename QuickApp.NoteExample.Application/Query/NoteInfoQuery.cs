/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 15:18:25
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Infrastructure;
using QuickApp.Infrastructure.Pageds;
using QuickApp.NoteExample.Application.Dto;
using QuickApp.NoteExample.Domain.Model;
using QuickApp.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Application.Query
{
    /// <summary>
    /// <see cref="NoteInfoQuery"/>
    /// </summary>
    public class NoteInfoQuery:INoteInfoQuery
    {
        private readonly IQuery query;

        public NoteInfoQuery(IQuery query)
        {
            this.query = query;
        }

        public IPaged<NoteInfoDto> GetPaged()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.AddSelectColumn("*")
                .AddOrderByAsc("ID")
                .AddPageInfo(10, 1);

            IPaged<NoteInfo> noteInfoPaged = this.query.FindPaged<NoteInfo>(queryBuilder);
            if (noteInfoPaged == null||noteInfoPaged.Data==null)
            {
                return null;
            }

            IList<NoteInfoDto> noteInfoDtoList = new List<NoteInfoDto>();
            foreach (NoteInfo noteInfo in noteInfoPaged.Data)
            {
                noteInfoDtoList.Add((NoteInfoDto)new NoteInfoDto().Mapping(noteInfo));
            }

            return new Paged<NoteInfoDto>(noteInfoPaged.TotalPage, noteInfoPaged.PageNumber, noteInfoPaged.TotalCount, noteInfoPaged.PageSize, noteInfoDtoList);

        }

        public Int32 GetCount()
        {
            return Convert.ToInt32(this.query.Find<Object>(new QueryBuilder().AddCount("*")));
        }

        public NoteInfoDto Get(Guid noteInfoID)
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.AddWhere(string.Format("ID='{0}'",noteInfoID.ToString()));

            NoteInfo noteInfo = this.query.Find<NoteInfo>(queryBuilder);
            if (noteInfo == null )
            {
                return null;
            }

            return (NoteInfoDto)new NoteInfoDto().Mapping(noteInfo);
        }
    }
}
