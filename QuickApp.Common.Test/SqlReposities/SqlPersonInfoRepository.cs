using QuickApp.Common.Test.Domain.Model;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.SqlReposities
{
    public class SqlPersonInfoRepository:QuickApp.Data.QuickDataRepository<PersonInfo,Guid>,IPersonInfoRepository
    {
        public SqlPersonInfoRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
            : base(currentRepositoryContextProvider)
        { 
        
        }
    }
}
