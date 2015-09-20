namespace AmazingTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubbItems",
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
                "dbo.AdditionalItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainTaskID = c.Int(),
                        Title = c.String(),
                        Description = c.String(),
                        Subcategory = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.TodoItems", "SubTasks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "SubTasks");
            DropTable("dbo.AdditionalItems");
            DropTable("dbo.SubbItems");
        }
    }
}
