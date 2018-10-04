using Logic.BL.Common.Domain.ValueObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.BL.Entities
{
    public class Customer //: Entity
    {
        public long CustomerId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        //public virtual Money Moneda { get; set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        //public virtual CustomerStatus Status { get; set; }

        //public virtual DateTime? StatusExpirationDate { get; set; }

        public virtual Money MoneySpent { get; set; }        
        //public virtual IList<PurchasedMovie> PurchasedMovies { get; set; }
        public Customer() { }
    }
}
