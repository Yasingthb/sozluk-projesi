namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writertitle_add1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "Writerİmage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "Writerİmage", c => c.String(maxLength: 100));
        }
    }
}
