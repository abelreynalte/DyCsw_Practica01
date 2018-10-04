using Logic.BL.Common.Infrastructure.Persistence.NHibernate;
using Logic.BL.Customers.Domain.Repository;
using Logic.BL.Entities;
using Logic.BL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BL.Repositories
{
    public class CustomerRepository : BaseNHibernateRepository<Customer>, ICustomerRepository//Repository<Customer>
    {
        public CustomerRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
        //public CustomerRepository(UnitOfWork unitOfWork)
        //    : base(unitOfWork)
        //{
        //}

        //public IReadOnlyList<Customer> GetList()
        //{
        //    return _unitOfWork
        //        .Query<Customer>()
        //        .ToList()
        //        .Select(
        //        x =>
        //        {
        //            x.PurchasedMovies = null;
        //            return x;
        //        }
        //        )
        //        .ToList();
        //}

        //public Customer GetByEmail(string email)
        //{
        //    return _unitOfWork
        //        .Query<Customer>()
        //        .SingleOrDefault(x => x.Email == email);
        //}
    }
}
