namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseNameColumnChangedToBeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccomodationPackages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AccomodationTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Accomodations", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accomodations", "Name", c => c.String());
            AlterColumn("dbo.AccomodationTypes", "Name", c => c.String());
            AlterColumn("dbo.AccomodationPackages", "Name", c => c.String());
        }
    }
}
