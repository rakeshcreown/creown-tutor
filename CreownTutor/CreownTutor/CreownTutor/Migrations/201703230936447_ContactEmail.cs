namespace CreownTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ContactEmail", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
