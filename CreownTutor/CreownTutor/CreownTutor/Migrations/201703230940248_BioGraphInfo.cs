namespace CreownTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BioGraphInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BioGraphInfo", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
