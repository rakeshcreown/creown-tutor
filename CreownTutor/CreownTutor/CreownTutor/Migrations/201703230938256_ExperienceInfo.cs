namespace CreownTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExperienceInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ExperienceInfo", c => c.String());
        }

        public override void Down()
        {
        }
    }
}
