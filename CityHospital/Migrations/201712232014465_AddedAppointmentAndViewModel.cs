namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppointmentAndViewModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Department_Id", "dbo.DepartmentTypes");
            DropIndex("dbo.Doctors", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Doctors", name: "Department_Id", newName: "DepartmentId");
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.DateTime(nullable: false),
                        Doctor_Id = c.Int(),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
            AlterColumn("dbo.Doctors", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "DepartmentId");
            AddForeignKey("dbo.Doctors", "DepartmentId", "dbo.DepartmentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DepartmentId", "dbo.DepartmentTypes");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "DepartmentId" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            AlterColumn("dbo.Doctors", "DepartmentId", c => c.Int());
            DropTable("dbo.Appointments");
            RenameColumn(table: "dbo.Doctors", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Doctors", "Department_Id");
            AddForeignKey("dbo.Doctors", "Department_Id", "dbo.DepartmentTypes", "Id");
        }
    }
}
