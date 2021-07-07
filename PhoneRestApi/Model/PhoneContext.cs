using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneRestApi.Model
{
    public class PhoneContext : DbContext
    {
        private string DBurl = @"Data Source = C:\temp\phone-records.db";
        public DbSet<Phone> PhoneItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(DBurl);
    }
}

