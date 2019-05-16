namespace collectible_figures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15052019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Figures", "Scale", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Figures", "Scale", c => c.String(nullable: false));
        }
    }
}
