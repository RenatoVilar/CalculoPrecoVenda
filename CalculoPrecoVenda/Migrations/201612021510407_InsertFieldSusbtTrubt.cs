namespace CalculoPrecoVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertFieldSusbtTrubt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ncms", "SubstTribut", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ncms", "SubstTribut");
        }
    }
}
