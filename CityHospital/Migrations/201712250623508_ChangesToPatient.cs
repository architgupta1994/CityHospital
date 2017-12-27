namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToPatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Patients", "Disease", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Disease", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
        }
    }
}
