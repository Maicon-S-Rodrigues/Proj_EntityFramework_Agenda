namespace Proj_EF_Agenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumbersAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PhoneNumbers_Mobile", c => c.String());
            AddColumn("dbo.People", "PhoneNumbers_Home", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PhoneNumbers_Home");
            DropColumn("dbo.People", "PhoneNumbers_Mobile");
        }
    }
}
