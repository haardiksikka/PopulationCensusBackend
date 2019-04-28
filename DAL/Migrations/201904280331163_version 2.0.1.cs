namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseListing", "Street", c => c.String(nullable: false));
            AddColumn("dbo.Population", "NameOfPerson", c => c.String(nullable: false));
            AddColumn("dbo.Population", "OccupationIndustry", c => c.String(nullable: false));
            DropColumn("dbo.Population", "FullNameOfThePerson");
            DropColumn("dbo.Population", "NatureOfOccupation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Population", "NatureOfOccupation", c => c.String(nullable: false));
            AddColumn("dbo.Population", "FullNameOfThePerson", c => c.String(nullable: false));
            DropColumn("dbo.Population", "OccupationIndustry");
            DropColumn("dbo.Population", "NameOfPerson");
            DropColumn("dbo.HouseListing", "Street");
        }
    }
}
