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
            AutomaticMigrationsEnabled = true;
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

           

        }
    }
}
