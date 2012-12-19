using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Sang.Models
{
    public class SangInitializer:DropCreateDatabaseIfModelChanges<SangDBContext>
    {
        protected override void Seed(SangDBContext context)
        {
            var warranties = new List<Warranty>
            {
                new Warranty 
                {
                    WarrantyCode = "LP1234",
                    IsActived = true,
                    NAttempts = 0,
                    ExpirationDate = DateTime.Now,
                    RegisterDate = DateTime.Now,
                    SangClient = null
                },
                new Warranty 
                {
                    WarrantyCode = "LP5678",
                    IsActived = true,
                    NAttempts = 0,
                    ExpirationDate = DateTime.Now,
                    RegisterDate = DateTime.Now,
                    SangClient = null
                }
            };
            warranties.ForEach(d => context.Warranties.Add(d));
        }
    }
}