namespace CalculoPrecoVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsereFieldAliquotaEmbarcacoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ufs", "AliquotaEmbarcacoes", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ufs", "AliquotaEmbarcacoes");
        }
    }
}
