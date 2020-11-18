using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BursApp.Models
{
    public class BursDBContext: DbContext
    {
        public BursDBContext() : base("BursDB1")
        {

        }
        public DbSet<Burslar> Burslar { get; set; }

    }
}