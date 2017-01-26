namespace CalculoPrecoVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsereCamposNcm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ncms", "Mva", c => c.Double());
            AddColumn("dbo.Ncms", "Autopecas", c => c.Int());
            AddColumn("dbo.Ncms", "SemSimilar", c => c.Int());
            AddColumn("dbo.Ncms", "Cest", c => c.String(maxLength: 100));
            DropColumn("dbo.Ncms", "SubstTribut");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ncms", "SubstTribut", c => c.Double());
            DropColumn("dbo.Ncms", "Cest");
            DropColumn("dbo.Ncms", "SemSimilar");
            DropColumn("dbo.Ncms", "Autopecas");
            DropColumn("dbo.Ncms", "Mva");
        }
    }
}
