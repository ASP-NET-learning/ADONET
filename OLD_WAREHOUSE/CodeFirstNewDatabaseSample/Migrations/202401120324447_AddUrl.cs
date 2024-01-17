namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Url");
        }
    }
}
