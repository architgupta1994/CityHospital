namespace CityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDoctors : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Doctors (Name, Department_Id) VALUES ('Manoj Kumar', 1), ('Sachin', 2), ('Ankit',3), ('Himanshu Sharma', 4), ('Neh Gupta', 5), ('Kartikya Thakur', 6), ('Akhil Tewatia', 7), ('Yashika Garg', 8), ('Shweta prasad', 9), ('Rupesh Bhoje', 10), ('Brad Darby', 1), ('Emmanuel', 5), ('Gopesh Chandra', 4),('Robin Joseph', 6)");
        }
        
        public override void Down()
        {
        }
    }
}
