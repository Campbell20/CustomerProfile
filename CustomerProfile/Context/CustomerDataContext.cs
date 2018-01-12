using CustomerProfile.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerProfile.Context
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext() : base("DefaultConnection")
        {

        }

        public DbSet<CustomerData> CustomerDatas { get; set; }
        public DbSet<CustomerImage> CustomerImages { get; set; }
    }
}