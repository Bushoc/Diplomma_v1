using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDiploma_v1.Context
{
    public class DiplomaContext : DbContext
    {
        public DbSet<Alphabet> Alphabets { get; set; }
        public DbSet<Letter> Letters { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //} 
    }
}
