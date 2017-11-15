using SQLite;

namespace AppTest.Tables
{
    public class Region
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
