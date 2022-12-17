namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "Recipt1", c => c.String());
            AddColumn("dbo.Options", "Recipt2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Options", "Recipt2");
            DropColumn("dbo.Options", "Recipt1");
        }
    }
}
