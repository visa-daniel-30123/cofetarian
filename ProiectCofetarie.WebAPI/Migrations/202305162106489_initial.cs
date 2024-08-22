namespace ProiectCofetarie.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IstoricComenzis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emailclient = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DenumireProd = c.String(),
                        Pret = c.Int(nullable: false),
                        Cantitate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        NumarComenzi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Produs");
            DropTable("dbo.IstoricComenzis");
        }
    }
}
