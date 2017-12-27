namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenders : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genders (Name) VALUES ('Male'), ('Female'), ('TransGender')");
        }
        
        public override void Down()
        {
        }
    }
}
