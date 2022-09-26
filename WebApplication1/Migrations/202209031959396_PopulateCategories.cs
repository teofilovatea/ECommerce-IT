namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('Face Masks')");
            Sql("INSERT INTO Categories (Name) VALUES ('Serums')");
            Sql("INSERT INTO Categories (Name) VALUES ('Toners')");
            Sql("INSERT INTO Products (Name) VALUES ('Effaclar Ultra Concentrated Serum')");
        }

        
        public override void Down()
        {
        }
    }
}
