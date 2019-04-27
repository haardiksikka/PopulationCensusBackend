namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseListing",
                c => new
                    {
                        HouseID = c.Int(nullable: false, identity: true),
                        HouseNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        State = c.String(nullable: false),
                        NameOfHead = c.String(nullable: false),
                        OwnerShipStatus = c.String(nullable: false),
                        NumberOfRooms = c.String(),
                    })
                .PrimaryKey(t => t.HouseID);
            
            CreateTable(
                "dbo.Population",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullNameOfThePerson = c.String(nullable: false),
                        RelationshipToHead = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MaritalStatus = c.String(nullable: false),
                        HouseID = c.Int(nullable: false),
                        AgeAtMarriage = c.Int(),
                        OccupationStatus = c.String(nullable: false),
                        NatureOfOccupation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HouseListing", t => t.HouseID, cascadeDelete: true)
                .Index(t => t.HouseID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ImageName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsApprover = c.Boolean(nullable: false),
                        VolunteerStatus = c.String(),
                        AdhaarNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Population", "HouseID", "dbo.HouseListing");
            DropIndex("dbo.Population", new[] { "HouseID" });
            DropTable("dbo.User");
            DropTable("dbo.Population");
            DropTable("dbo.HouseListing");
        }
    }
}
