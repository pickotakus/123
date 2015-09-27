namespace AmazingTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubbbItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainCategoryID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Subtasks = c.String(),
                        Notes = c.String(),
                        Attachments = c.String(),
                        Priority = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AddditionalItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainTaskID = c.Int(),
                        Title = c.String(),
                        Description = c.String(),
                        Subcategory = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.TodoItems", "SubTasks1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "SubTasks1");
            DropTable("dbo.AdditionalItems");
            DropTable("dbo.SubbItems");
        }
    }
}
