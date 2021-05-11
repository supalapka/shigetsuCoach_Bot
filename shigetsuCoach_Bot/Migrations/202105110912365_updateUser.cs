namespace shigetsuCoach_Bot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "phoneNumber", c => c.String());
            AlterColumn("dbo.Users", "UserTelegramId", c => c.Long(nullable: false));

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserTelegramId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "phoneNumber");
        }

    }
}
