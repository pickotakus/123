namespace AmazingTodo.Migrations
{
    using AmazingTodo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AmazingTodo.Models.AmazingTodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AmazingTodo.Models.AmazingTodoContext context)
        {
            var tasks = new List<TodoItem>
            {
                new TodoItem { TodoItemId = 1,   Todo = "Personal Errands", Priority=0, 
                    DueDate = DateTime.Parse("2010-09-01"), SubTasks = "1;3;4" },
                new TodoItem { TodoItemId = 2,   Todo = "Work Related Errands", Priority=0, 
                    DueDate = DateTime.Parse("2010-09-01"), SubTasks = "2" },
                new TodoItem { TodoItemId = 3,   Todo = "Groceries", Priority=0,
                    DueDate = DateTime.Parse("2010-09-01"), SubTasks = "" },
                new TodoItem { TodoItemId = 4,   Todo = "Family",Priority=0,
                    DueDate = DateTime.Parse("2010-09-01"), SubTasks = "" },
                new TodoItem { TodoItemId = 5,   Todo = "Personal Goals", Priority=0,
                    DueDate = DateTime.Parse("2010-09-01"), SubTasks = "" }
            };
            tasks.ForEach(s => context.TodoItems.AddOrUpdate(p => p.TodoItemId, s));
            context.SaveChanges();

            var subs = new List<SubbItem>
            {
                new SubbItem {ID = 1, MainCategoryID = 1, 
                    Title = "SubTask1",Description= "SubTask1", Subtasks = "", Notes="", Attachments="", Priority=false},
                new SubbItem {ID = 2, 
                    MainCategoryID = 1,
                    Title = "SubTask2",Description= "SubTask2", Subtasks = "", Notes="", Attachments="", Priority=false },
                new SubbItem {ID = 3, 
                    MainCategoryID = 2,
                    Title = "SubTask3",Description= "SubTask2", Subtasks = "", Notes="", Attachments="", Priority=false },
                new SubbItem {ID = 4, 
                    MainCategoryID = 1,
                    Title = "SubTask4",Description= "SubTask2", Subtasks = "", Notes="", Attachments="", Priority=false }

            };
            subs.ForEach(s => context.SubItems.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var adds = new List<AdditionalItem>
            {
                new AdditionalItem { 
                    ID = 1, 
                    MainTaskID = 1, 
                    Title = "AddTask1", Description= "AddTask1", Subcategory=""
                },
                 new AdditionalItem { 
                    ID = 2, 
                    MainTaskID = 1, 
                    Title = "AddTask2", Description= "AddTask2", Subcategory=""
                },
            };
            adds.ForEach(s => context.AddItems.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
        }
    }
}
