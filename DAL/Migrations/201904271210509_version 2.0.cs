namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Population", "HouseID", "dbo.HouseListing");
            DropIndex("dbo.Population", new[] { "HouseID" });
            AddColumn("dbo.HouseListing", "City", c => c.String(nullable: false));
            AddColumn("dbo.HouseListing", "Pincode", c => c.String(nullable: false));
            AddColumn("dbo.HouseListing", "CensusHouseNumber", c => c.String(nullable: false));
            AddColumn("dbo.Population", "CensusHouseNumber", c => c.String());
            AddColumn("dbo.Population", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Population", "Income", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseListing", "NumberOfRooms", c => c.String(nullable: false));
            DropColumn("dbo.HouseListing", "Address");
            DropColumn("dbo.Population", "HouseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Population", "HouseID", c => c.Int(nullable: false));
            AddColumn("dbo.HouseListing", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.HouseListing", "NumberOfRooms", c => c.String());
            DropColumn("dbo.Population", "Income");
            DropColumn("dbo.Population", "Age");
            DropColumn("dbo.Population", "CensusHouseNumber");
            DropColumn("dbo.HouseListing", "CensusHouseNumber");
            DropColumn("dbo.HouseListing", "Pincode");
            DropColumn("dbo.HouseListing", "City");
            CreateIndex("dbo.Population", "HouseID");
            AddForeignKey("dbo.Population", "HouseID", "dbo.HouseListing", "HouseID", cascadeDelete: true);
        }
    }
}
