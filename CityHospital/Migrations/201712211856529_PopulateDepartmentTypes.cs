namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepartmentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DepartmentTypes (Name) VALUES ('Accident and Emergency (A&E)'), ('Cardiology'), ('Intensive Critical Unit (ICU)'), ('Ear, Nose adn Throat (ENT)'), ('Nutrition and Deitetics'), ('Gynaecology Unit'), ('Orthopaedics'), ('Physitherapy'), ('Eye Care Unit (ECU)'), ('General Surgery')");
        }
        
        public override void Down()
        {
        }
    }
}
