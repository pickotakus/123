﻿using System.Data.Entity;

namespace AmazingTodo.Models {
    public class AmazingTodoContext : DbContext {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<AmazingTodo.Models.AmazingTodoContext>());

        public AmazingTodoContext() : base("name=AmazingTodoContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AmazingTodoContext, Migrations.Configuration>());
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<SubbItem> SubItems { get; set; }
        public DbSet<AdditionalItem> AddItems { get; set; }
    }
}
