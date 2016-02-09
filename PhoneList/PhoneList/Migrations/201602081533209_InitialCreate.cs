namespace PhoneList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataAdresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Street = c.String(),
                        HouseNo = c.String(),
                        Lng = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        PersonId = c.Int(nullable: false),
                        DataPerson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataCities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.DataPersons", t => t.DataPerson_Id)
                .ForeignKey("dbo.DataPersons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.PersonId)
                .Index(t => t.DataPerson_Id);
            
            CreateTable(
                "dbo.DataCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataCountries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.DataCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DataAdress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.DataAdresses", t => t.DataAdress_Id)
                .Index(t => t.UserId)
                .Index(t => t.DataAdress_Id);
            
            CreateTable(
                "dbo.DataPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        PhoneType = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataPersons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.DataUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(),
                        Photo = c.String(),
                        Login = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(),
                        Photo = c.String(),
                        Login = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AdressViewModel_Id = c.Int(),
                        UserViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdressViewModels", t => t.AdressViewModel_Id)
                .ForeignKey("dbo.UserViewModels", t => t.UserViewModel_Id)
                .Index(t => t.AdressViewModel_Id)
                .Index(t => t.UserViewModel_Id);
            
            CreateTable(
                "dbo.AdressViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        CountryId = c.Int(nullable: false),
                        City = c.String(),
                        CityId = c.Int(nullable: false),
                        Street = c.String(),
                        HouseNo = c.String(),
                        Lng = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        person_Id = c.Int(),
                        PersonViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonViewModels", t => t.person_Id)
                .ForeignKey("dbo.PersonViewModels", t => t.PersonViewModel_Id)
                .Index(t => t.person_Id)
                .Index(t => t.PersonViewModel_Id);
            
            CreateTable(
                "dbo.PhoneViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        PhoneType = c.String(),
                        PersonId = c.Int(nullable: false),
                        PersonViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonViewModels", t => t.PersonViewModel_Id)
                .Index(t => t.PersonViewModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonViewModels", "UserViewModel_Id", "dbo.UserViewModels");
            DropForeignKey("dbo.PhoneViewModels", "PersonViewModel_Id", "dbo.PersonViewModels");
            DropForeignKey("dbo.AdressViewModels", "PersonViewModel_Id", "dbo.PersonViewModels");
            DropForeignKey("dbo.PersonViewModels", "AdressViewModel_Id", "dbo.AdressViewModels");
            DropForeignKey("dbo.AdressViewModels", "person_Id", "dbo.PersonViewModels");
            DropForeignKey("dbo.DataPersons", "DataAdress_Id", "dbo.DataAdresses");
            DropForeignKey("dbo.DataAdresses", "PersonId", "dbo.DataPersons");
            DropForeignKey("dbo.DataPersons", "UserId", "dbo.DataUsers");
            DropForeignKey("dbo.DataPhones", "PersonId", "dbo.DataPersons");
            DropForeignKey("dbo.DataAdresses", "DataPerson_Id", "dbo.DataPersons");
            DropForeignKey("dbo.DataAdresses", "CityId", "dbo.DataCities");
            DropForeignKey("dbo.DataCities", "CountryId", "dbo.DataCountries");
            DropIndex("dbo.PhoneViewModels", new[] { "PersonViewModel_Id" });
            DropIndex("dbo.AdressViewModels", new[] { "PersonViewModel_Id" });
            DropIndex("dbo.AdressViewModels", new[] { "person_Id" });
            DropIndex("dbo.PersonViewModels", new[] { "UserViewModel_Id" });
            DropIndex("dbo.PersonViewModels", new[] { "AdressViewModel_Id" });
            DropIndex("dbo.DataPhones", new[] { "PersonId" });
            DropIndex("dbo.DataPersons", new[] { "DataAdress_Id" });
            DropIndex("dbo.DataPersons", new[] { "UserId" });
            DropIndex("dbo.DataCities", new[] { "CountryId" });
            DropIndex("dbo.DataAdresses", new[] { "DataPerson_Id" });
            DropIndex("dbo.DataAdresses", new[] { "PersonId" });
            DropIndex("dbo.DataAdresses", new[] { "CityId" });
            DropTable("dbo.PhoneViewModels");
            DropTable("dbo.AdressViewModels");
            DropTable("dbo.PersonViewModels");
            DropTable("dbo.UserViewModels");
            DropTable("dbo.DataUsers");
            DropTable("dbo.DataPhones");
            DropTable("dbo.DataPersons");
            DropTable("dbo.DataCountries");
            DropTable("dbo.DataCities");
            DropTable("dbo.DataAdresses");
        }
    }
}
