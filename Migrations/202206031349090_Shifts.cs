namespace CompanySchedulces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shifts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Shifts",
               c => new
               {
                   ShiftsID = c.Int(nullable: false, identity: true),
                   ShiftsStart_Time = c.String(),
                   ShiftsEnd_Time = c.String(),
               })
               .PrimaryKey(t => t.ShiftsID);

        }

        public override void Down()
        {

            DropTable("dbo.Shifts");
        }
    }
}
