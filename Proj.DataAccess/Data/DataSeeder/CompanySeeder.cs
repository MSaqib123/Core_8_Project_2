using Microsoft.EntityFrameworkCore;
using Proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.DataAccess.Data.DataSeeder
{
    public static class CompanySeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(
                new Company
                { 
                    Id=1,
                    Name = "Company1",
                    City = "karachi",
                    State="Pakistan",
                    PhoneNumber = "234324",
                    PostalCode="234",
                    StreetAddress = "Laptaa"
                },
                new Company
                { 
                    Id=1,
                    Name = "Company2",
                    City = "karachi",
                    State="Pakistan",
                    PhoneNumber = "234324",
                    PostalCode="234",
                    StreetAddress = "Laptaa"
                },
                new Company
                { 
                    Id=1,
                    Name = "Company3",
                    City = "karachi",
                    State="Pakistan",
                    PhoneNumber = "234324",
                    PostalCode="234",
                    StreetAddress = "Laptaa"
                },
                new Company
                { 
                    Id=1,
                    Name = "Company5",
                    City = "karachi",
                    State="Pakistan",
                    PhoneNumber = "234324",
                    PostalCode="234",
                    StreetAddress = "Laptaa"
                },
                new Company
                { 
                    Id=1,
                    Name = "Company6",
                    City = "karachi",
                    State="Pakistan",
                    PhoneNumber = "234324",
                    PostalCode="234",
                    StreetAddress = "Laptaa"
                }                
              );
        }
    }
}
