namespace collectible_figures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondVersion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Figures", "Name", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Figures", "Name", c => c.String(nullable: false));
        }
    }
}
