using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Sang.Models
{
    public class SangDBContext : DbContext
    {
        //Use this code in only in the development server
        public SangDBContext()
            : base("name=SangDBContext")
        { }
        //-----------------------------------------------------
        public DbSet<SangUser> SangUsers { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<ModelMattress> ModelMattress { get; set; }
        public DbSet<Warranty> Warranties { get; set; }
        public DbSet<SangClient> SangClients { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<SangChild> SangChildren { get; set; }
        //public DbSet<Coupon> Coupons { get; set; }
    }
}