using System;
using SQLite;

namespace AppTest.Tables
{
    public class TaskTable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
