using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.BL.Common.Application
{
    public interface IUnitOfWork
    {
        bool BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit(bool commit);
        void Rollback(bool rollback);
    }
}
