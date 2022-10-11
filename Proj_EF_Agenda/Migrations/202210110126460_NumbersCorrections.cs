namespace Proj_EF_Agenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumbersCorrections : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Phone");
            DropColumn("dbo.People", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Mobile", c => c.String());
            AddColumn("dbo.People", "Phone", c => c.String());
        }
    }
}
