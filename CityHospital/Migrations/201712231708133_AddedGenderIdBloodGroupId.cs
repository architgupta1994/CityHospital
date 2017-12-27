namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenderIdBloodGroupId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Patients", name: "BloodGroup_Id", newName: "BloodGroupId");
            RenameColumn(table: "dbo.Patients", name: "Gender_Id", newName: "GenderId");
            RenameIndex(table: "dbo.Patients", name: "IX_Gender_Id", newName: "IX_GenderId");
            RenameIndex(table: "dbo.Patients", name: "IX_BloodGroup_Id", newName: "IX_BloodGroupId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Patients", name: "IX_BloodGroupId", newName: "IX_BloodGroup_Id");
            RenameIndex(table: "dbo.Patients", name: "IX_GenderId", newName: "IX_Gender_Id");
            RenameColumn(table: "dbo.Patients", name: "GenderId", newName: "Gender_Id");
            RenameColumn(table: "dbo.Patients", name: "BloodGroupId", newName: "BloodGroup_Id");
        }
    }
}
