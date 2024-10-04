namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retenuuu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Retenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        MontantRetenue = c.Decimal(nullable: false, precision: 18, scale: 6),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 6),
                        Commentaire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Retenues");
        }
    }
}
