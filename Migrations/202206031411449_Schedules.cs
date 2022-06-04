namespace CompanySchedulces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Schedules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        ScheduleDate = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        ShiftsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.ShiftsID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ShiftsID);
        
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ShiftsID", "dbo.Shifts");
            DropForeignKey("dbo.Schedules", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Schedules", new[] { "ShiftsID" });
            DropIndex("dbo.Schedules", new[] { "EmployeeID" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Schedules");
        }
    }
}
