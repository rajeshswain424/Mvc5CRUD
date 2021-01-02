using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EfCrud.Models
{
    public class MvcDbcontext:DbContext
    {
        public MvcDbcontext() : base("MvcConnection")
        {

        }
        public DbSet<Products> tableProducts { get; set; }
    }
}