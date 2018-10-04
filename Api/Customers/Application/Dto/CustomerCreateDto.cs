using Logic.BL.Common.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Customers.Application.Dto
{
    public class CustomerCreateDto
    {
        public long CustomerId { get; set; }
        public virtual string Name { get; set; }        
        public virtual string Email { get; set; }
        public virtual decimal MoneySpent { get; set; }        
        public Currency Currency { get; set; }
    }
}
