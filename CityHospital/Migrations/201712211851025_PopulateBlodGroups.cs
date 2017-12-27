namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBlodGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BloodGroups(Name) Values('A+'), ('A-'), ('O+'), ('O-'), ('B+'), ('B-'), ('AB+'), ('AB-')");
        }
        
        public override void Down()
        {
        }
    }
}
