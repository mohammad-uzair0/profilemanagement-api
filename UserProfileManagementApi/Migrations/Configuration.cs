namespace UserProfileManagementApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UserProfileManagementApi.Data.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<UserProfileManagementApi.Data.Context.UserProfileDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserProfileManagementApi.Data.Context.UserProfileDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var userProfiles = new List<UserProfile>
            {
                new UserProfile
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890",
                    Address = "123 Main St, Anytown, USA",
                    PortfolioUrl = "http://johndoe.com",
                    ProfileImage = null
                },
                new UserProfile
                {
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Phone = "987-654-3210",
                    Address = "456 Elm St, Othertown, USA",
                    PortfolioUrl = "http://janesmith.com",
                    ProfileImage = null
                },
                new UserProfile
                {
                    Name = "Sam Johnson",
                    Email = "sam.johnson@example.com",
                    Phone = "555-555-5555",
                    Address = "789 Oak St, Sometown, USA",
                    PortfolioUrl = "http://samjohnson.com",
                    ProfileImage = null
                }
            };

            userProfiles.ForEach(up => context.UserProfile.Add(up));
            context.SaveChanges();
        }
    }
}
