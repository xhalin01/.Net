namespace iwSubjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskEvaluations", "StudentFk", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskEvaluations", "StudentFk");
        }
    }
}
