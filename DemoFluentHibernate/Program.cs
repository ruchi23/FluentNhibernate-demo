using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoFluentHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    var ProductObject = new Product
                    {
                        Name = "Moto G 4 Plus",
                        Description = "Smartphone VoLTE enabled"

                    };
                    session.Save(ProductObject);
                    transaction.Commit();
                    Console.WriteLine("product Created : " + ProductObject.Name);
                }

                Console.ReadKey();
            }
        }
    }
}
