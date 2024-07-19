namespace UserProfileManagementApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    Email = c.String(nullable: false, maxLength: 255),
                    Phone = c.String(nullable: true, maxLength: 55),
                    Address = c.String(nullable: true, maxLength: 255),
                    PortfolioUrl = c.String(nullable: true, maxLength: 200),
                    ProfileImage = c.Binary(nullable: true),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.UserProfile");
        }
    }
}
