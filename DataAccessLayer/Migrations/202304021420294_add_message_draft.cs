namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_message_draft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DraftMessage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DraftMessage");
        }
    }
}
