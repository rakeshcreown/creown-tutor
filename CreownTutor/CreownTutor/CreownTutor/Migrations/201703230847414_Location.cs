namespace CreownTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location : DbMigration
    {
        public override void Up()
        {

            //AddColumn("dbo.AspNetUsers", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "ContactEmail", c => c.String());
            AddColumn("dbo.AspNetUsers", "ExperienceInfo", c => c.String());
            AddColumn("dbo.AspNetUsers", "BioGraphInfo", c => c.String());
            AddColumn("dbo.AspNetUsers", "Imagelength", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
