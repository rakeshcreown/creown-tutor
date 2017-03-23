namespace CreownTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imagelength : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Imagelength", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
