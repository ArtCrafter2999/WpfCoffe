using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp2
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection"){ }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
