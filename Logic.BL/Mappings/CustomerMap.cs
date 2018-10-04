using Logic.BL.Entities;
using FluentNHibernate.Mapping;

namespace Logic.BL.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            //Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Email);
            //Map(x => x.Status).CustomType<int>();
            //Map(x => x.StatusExpirationDate).Nullable();
            Map(x => x.MoneySpent);

            //HasMany(x => x.PurchasedMovies);
        }
    }
}
