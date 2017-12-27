namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePatients : DbMigration
    {
        public override void Up()
        {
            
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroup_Id, Gender_Id) Values ('Manish', 'Kapoor', @DateOfJoin, '35', 9898989898, 'Add1', 'Fever', 1, 1)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroup_Id, Gender_Id) Values ('Rohit', 'Adhikari', @DateOfJoin, '26', 9898989800, 'Add2', 'Eye infection', 4, 1)");
            Sql("DECLARE @DateOfJoin DATETIME = GetDate() INSERT INTO Patients (FirstName, LastName, DateOfJoin, Age, CellPhone, Address, Disease, BloodGroup_Id, Gender_Id) Values ('Kirit', 'Singh', @DateOfJoin, '25', 9800980000, 'Add3', 'Food Poisoning', 7, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
