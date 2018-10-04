using Logic.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.BL.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Delete(Customer customer);
        Customer Read(long id);
    }
}
