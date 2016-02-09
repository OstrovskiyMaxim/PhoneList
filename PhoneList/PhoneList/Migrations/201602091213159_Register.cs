namespace PhoneList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Register : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataUsers", "Password", c => c.String());
            AddColumn("dbo.DataUsers", "Role", c => c.String());
            AddColumn("dbo.UserViewModels", "Password", c => c.String());
            AddColumn("dbo.UserViewModels", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserViewModels", "Role");
            DropColumn("dbo.UserViewModels", "Password");
            DropColumn("dbo.DataUsers", "Role");
            DropColumn("dbo.DataUsers", "Password");
        }
    }
}
