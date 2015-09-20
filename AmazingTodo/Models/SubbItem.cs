using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazingTodo.Models
{
    public class SubbItem
    {
        public int ID { get; set; }
        public int MainCategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtasks { get; set; }
        public string Notes { get; set; }
        public string Attachments { get; set; }
        public Nullable<bool> Priority { get; set; }
    }
}