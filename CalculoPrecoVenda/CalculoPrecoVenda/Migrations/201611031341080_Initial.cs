namespace CalculoPrecoVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ncms",
                c => new
                    {
                        NcmId = c.Int(nullable: false, identity: true),
                        CodNcm = c.String(nullable: false, maxLength: 10, unicode: false),
                        NomeNcm = c.String(nullable: false, maxLength: 150, unicode: false),
                        ImpImportacao = c.Double(nullable: false),
                        Ipi = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NcmId);
            
            CreateTable(
                "dbo.Ufs",
                c => new
                    {
                        UnidadeFederadaId = c.Int(nullable: false, identity: true),
                        NomeUf = c.String(nullable: false, maxLength: 30, unicode: false),
                        Sigla = c.String(nullable: false, maxLength: 2, unicode: false),
                        AliquotaInterna = c.Double(nullable: false),
                        AliquotaFcp = c.Double(nullable: false),
                        ItensFcp = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.UnidadeFederadaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ufs");
            DropTable("dbo.Ncms");
        }
    }
}
