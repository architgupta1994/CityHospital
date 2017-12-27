namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            RenameColumn(table: "dbo.Appointments", name: "Doctor_Id", newName: "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "Patient_Id", newName: "PatientId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Patient_Id", newName: "IX_PatientId");
            AlterColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            AlterColumn("dbo.Appointments", "DoctorId", c => c.Int());
            RenameIndex(table: "dbo.Appointments", name: "IX_PatientId", newName: "IX_Patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "Patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "Doctor_Id");
            CreateIndex("dbo.Appointments", "Doctor_Id");
            AddForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
