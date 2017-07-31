using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoFluentHibernate
{
    class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap() {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.CustomerProduct).Column("ProductId");
            Table("Customer");
        }

    }
   
}
