using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazingTodo.Models
{
    public class AdditionalItem
    {
        public int ID { get; set; }
        public Nullable<int> MainTaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subcategory { get; set; }

    }
}