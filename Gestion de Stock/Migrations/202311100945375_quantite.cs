﻿namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LigneProductions", "RendementLignePTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.LigneProductions", "valeurLignePTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.LigneProductions", "PULigneProdTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LigneProductions", "PULigneProdTotal");
            DropColumn("dbo.LigneProductions", "valeurLignePTotal");
            DropColumn("dbo.LigneProductions", "RendementLignePTotal");
        }
    }
}
