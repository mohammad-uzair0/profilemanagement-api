using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserProfileManagementApi.Data.Domain;

namespace UserProfileManagementApi.Data.Context
{
    public class UserProfileDbContext : DbContext
    {
        public UserProfileDbContext() : base("name=UserProfileDBConnectionString")
        {
        }

        public DbSet<UserProfile> UserProfile { get; set; }
    }
}