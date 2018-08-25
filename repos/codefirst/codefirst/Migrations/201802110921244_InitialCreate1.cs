namespace codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Mobile", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Address", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.Int(nullable: false));
        }
    }
}
