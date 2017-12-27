namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAppointments : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @AptDate DATETIME = GETDATE() INSERT INTO Appointments (AppointmentDate, DoctorId, PatientId) VALUES(@AptDate,1,2), (@AptDate,2,1), (@AptDate,3,4)");
        }
        
        public override void Down()
        {
        }
    }
}
