namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personnelisteachat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonneListeAchats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cin = c.String(),
                        FullName = c.String(),
                        Numero = c.String(),
                        Tel = c.String(),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 6),
                        Achat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_Id)
                .Index(t => t.Achat_Id);
            
            AddColumn("dbo.HistoriquePaiementAchats", "PersonneListeAchat_Id", c => c.Int());
            CreateIndex("dbo.HistoriquePaiementAchats", "PersonneListeAchat_Id");
            AddForeignKey("dbo.HistoriquePaiementAchats", "PersonneListeAchat_Id", "dbo.PersonneListeAchats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoriquePaiementAchats", "PersonneListeAchat_Id", "dbo.PersonneListeAchats");
            DropForeignKey("dbo.PersonneListeAchats", "Achat_Id", "dbo.Achats");
            DropIndex("dbo.PersonneListeAchats", new[] { "Achat_Id" });
            DropIndex("dbo.HistoriquePaiementAchats", new[] { "PersonneListeAchat_Id" });
            DropColumn("dbo.HistoriquePaiementAchats", "PersonneListeAchat_Id");
            DropTable("dbo.PersonneListeAchats");
        }
    }
}
