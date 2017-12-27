namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePatientsWithMoreData : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroupId, GenderId) Values ('Thomas', 'Kyfer', @DateOfJoin, '35', 9568989898, 'AddAdd2', 'Jaundice', 4,1)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroupId, GenderId) Values ('Nithya', 'Murugesan', @DateOfJoin, '28', 98989486800, 'AddAdd32', 'Cold and Cuff', 6, 2)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroupId, GenderId) Values ('Shivangi', 'Arora', @DateOfJoin, '27', 9889980000, 'AddAdd3', 'Food Poisoning', 5, 2)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroupId, GenderId) Values ('Milt', 'Richter', @DateOfJoin, '46', 9568980000, 'Add2Add', 'Headache', 3,1)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroupId, GenderId) Values ('Ubey', 'Kesler', @DateOfJoin, '24', 9898948110, 'Add32Add', 'Cold and Headache', 7, 1)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroupId, GenderId) Values ('Kabir', 'Elawat', @DateOfJoin, '28', 9810098100, 'Add3Add', 'Acne', 4, 1)");

        }

        public override void Down()
        {
        }
    }
}
