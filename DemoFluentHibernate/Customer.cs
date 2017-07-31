using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoFluentHibernate
{
    class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Product CustomerProduct { get; set; }
    }
}
