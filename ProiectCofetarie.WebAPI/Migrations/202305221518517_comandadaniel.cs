namespace ProiectCofetarie.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comandadaniel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IstoricComenzis", "Comanda", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IstoricComenzis", "Comanda");
        }
    }
}
