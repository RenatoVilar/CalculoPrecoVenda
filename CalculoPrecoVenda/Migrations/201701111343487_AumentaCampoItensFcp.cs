namespace CalculoPrecoVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AumentaCampoItensFcp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ufs", "ItensFcp", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ufs", "ItensFcp", c => c.String(nullable: false, maxLength: 300, unicode: false));
        }
    }
}
