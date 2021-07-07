using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneRestApi.Model
{
    public class PhoneContext : DbContext
    {
 
        public DbSet<Phone> PhoneItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source = C:\temp\phone-records.db");
    }
}

