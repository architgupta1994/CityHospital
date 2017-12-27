namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeCellPhoneDateOfJoinNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DateOfJoin", c => c.DateTime());
            AlterColumn("dbo.Patients", "Age", c => c.Int());
            AlterColumn("dbo.Patients", "CellPhone", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "CellPhone", c => c.Long(nullable: false));
            AlterColumn("dbo.Patients", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "DateOfJoin", c => c.DateTime(nullable: false));
        }
    }
}
