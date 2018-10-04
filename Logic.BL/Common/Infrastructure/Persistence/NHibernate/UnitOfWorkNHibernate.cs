using Logic.BL.Common.Application;
using Logic.BL.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
//using System.ServiceModel.Channels;
using System.Text;

namespace Logic.BL.Common.Infrastructure.Persistence.NHibernate
{
    public class UnitOfWorkNHibernate: IUnitOfWork
    {
        private SessionFactory _sessionFactory;
        private ISession _session;
        private ITransaction _transaction;

        public UnitOfWorkNHibernate(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public ISession GetSession()
        {
            return _session;
        }

        public bool BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_transaction == null || !_transaction.IsActive)
            {
                _session = _sessionFactory.OpenSession();
                _transaction = _session.BeginTransaction(isolationLevel);
                return true;
            }
            return false;
        }

        public void Commit(bool commit)
        {
            if (_transaction != null && _transaction.IsActive && commit)
            {
                try
                {
                    _transaction.Commit();
                }
                finally
                {
                    _transaction.Dispose();
                    _session.Close();
                    _session.Dispose();
                }
            }
        }

        public void Rollback(bool rollback)
        {
            if (_transaction != null && _transaction.IsActive && rollback)
            {
                try
                {
                    _transaction.Rollback();
                }
                finally
                {
                    _transaction.Dispose();
                    _session.Close();
                    _session.Dispose();
                }
            }
        }
    }
}
