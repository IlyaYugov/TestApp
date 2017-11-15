using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppTest.Tables
{
    public class User
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public int RegionID { get; set; }

        public int TaskID { get; set; }
    }
}
