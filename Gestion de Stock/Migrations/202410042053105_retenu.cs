namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonneListeAchats", "Achat_Id", "dbo.Achats");
            DropIndex("dbo.PersonneListeAchats", new[] { "Achat_Id" });
            DropColumn("dbo.PersonneListeAchats", "Achat_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonneListeAchats", "Achat_Id", c => c.Int());
            CreateIndex("dbo.PersonneListeAchats", "Achat_Id");
            AddForeignKey("dbo.PersonneListeAchats", "Achat_Id", "dbo.Achats", "Id");
        }
    }
}
