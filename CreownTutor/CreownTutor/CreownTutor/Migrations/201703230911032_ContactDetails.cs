namespace CreownTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ContactDetails", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
