using ppedv.ADC2019.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ADC2019.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Standort> Standorte { get; set; }
        public DbSet<Vermietung> Vermietungen { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this($"Server=.\\SQLEXPRESS;Database=ADC2019_dev;Trusted_Connection=true")
        //   public EfContext() : this($"Server=(localdb)\\mssqllocaldb;Database=ADC2019_dev;Trusted_Connection=true")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //msdn.com/data/ef
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<Auto>().Property(x => x.Farbe).IsRequired();
        }
    }
}
