using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest
{
    public class TaskViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }


        public bool IsMatchForSearch(string searchString)
        {
            searchString = searchString.ToLower();
            return Name.ToLower().Contains(searchString)
                || Description.ToLower().Contains(searchString);
        }
    }
}
