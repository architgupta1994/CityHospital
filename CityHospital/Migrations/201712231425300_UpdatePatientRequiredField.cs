namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientRequiredField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "BloodGroup_Id", "dbo.BloodGroups");
            DropForeignKey("dbo.Patients", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Patients", new[] { "BloodGroup_Id" });
            DropIndex("dbo.Patients", new[] { "Gender_Id" });
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Disease", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "BloodGroup_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Gender_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "BloodGroup_Id");
            CreateIndex("dbo.Patients", "Gender_Id");
            AddForeignKey("dbo.Patients", "BloodGroup_Id", "dbo.BloodGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "Gender_Id", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Patients", "BloodGroup_Id", "dbo.BloodGroups");
            DropIndex("dbo.Patients", new[] { "Gender_Id" });
            DropIndex("dbo.Patients", new[] { "BloodGroup_Id" });
            AlterColumn("dbo.Patients", "Gender_Id", c => c.Int());
            AlterColumn("dbo.Patients", "BloodGroup_Id", c => c.Int());
            AlterColumn("dbo.Patients", "Disease", c => c.String());
            AlterColumn("dbo.Patients", "Address", c => c.String());
            AlterColumn("dbo.Patients", "LastName", c => c.String());
            AlterColumn("dbo.Patients", "FirstName", c => c.String());
            CreateIndex("dbo.Patients", "Gender_Id");
            CreateIndex("dbo.Patients", "BloodGroup_Id");
            AddForeignKey("dbo.Patients", "Gender_Id", "dbo.Genders", "Id");
            AddForeignKey("dbo.Patients", "BloodGroup_Id", "dbo.BloodGroups", "Id");
        }
    }
}
