using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ATMDemoWithWPF.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class EFCFContext : DbContext
    {
        public EFCFContext() : base("name=efcfconnstr")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }






    }
}
