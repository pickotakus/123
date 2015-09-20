using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    using System.Data.Entity.Migrations;

namespace AmazingTodo.Migrations
{
    public class Add_Tables: DbMigration
    {
        public override void Up()
        {
           CreateTable(
                "dbo.SubCats",
                c => new
                {
                    SubCatId = c.Int(nullable: false, identity: true),
                    MainCatId = c.Int(),
                    SubCat = c.String(),
                    Priority = c.Byte(nullable: false),
                    DueDate = c.DateTime(),
                    Attachments = c.String(),
                    Notes = c.String(),
                })
                .PrimaryKey(t => t.SubCatId);
            CreateTable(
                "dbo.AddItems",
                c => new
                {
                    AddId = c.Int(nullable: false, identity: true),
                    MainCatId = c.Int(),
                    AddItem = c.String(),
                    DueDate = c.DateTime(),
                    IsNote = c.Byte(nullable: false),
                    Attachments = c.String(),
                    Notes = c.String(),
                })
                .PrimaryKey(t => t.AddId);
        }
        
        public override void Down()
        {
        }
    }
}