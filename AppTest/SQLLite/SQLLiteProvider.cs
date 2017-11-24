using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AppTest.Tables;
using SQLite;

namespace AppTest
{
    public static class SQLLiteProvider
    {

        private static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DataBase.sqlite3");
        public static void CreateDataBase()
        {
            using (var connection = CreateConnection())
            {
                connection.CreateTable<User>();
                connection.CreateTable<Region>();
                connection.CreateTable<TaskTable>();
                connection.CreateTable<Coordinate>();
            }
        }

        public static SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection(path, false);

            return connection;
        }

        public static bool DataBaseIsExist()
        {
            return File.Exists(path);
        }

        public static void FillDataBase()
        {
            using (var connection = CreateConnection())
            {
                Region region1 = new Region
                {
                    Name = "RegionVasek"
                };

                TaskTable task1 = new TaskTable
                {
                    Date = DateTime.Now,
                    Description = "Srochno Iopt",
                    Name = "Вааажно"
                };

                TaskTable task2 = new TaskTable
                {
                    Date = DateTime.Now,
                    Description = "Принеси",
                    Name = "Менее Вааажно"
                };

                TaskTable task3 = new TaskTable
                {
                    Date = DateTime.Now,
                    Description = "Подай",
                    Name = "Более Вааажно"
                };

                TaskTable task4 = new TaskTable
                {
                    Date = DateTime.Now,
                    Description = "Не мешай",
                    Name = "Насрать как Вааажно"
                };

                connection.Insert(region1);

                connection.Insert(task1);
                connection.Insert(task2);
                connection.Insert(task3);
                connection.Insert(task4);

                User user1 = new User
                {
                    FullName = "Vasiya",
                    Name = "Vasek",
                    RegionID = connection.Table<Region>().Where(w => w.Name == "RegionVasek").Select(s => s.ID).First()
                    //TaskID = connection.Table<TaskTable>().Where(w => w.Name == "QWEasdzxc").Select(s => s.ID).First()
                };
                connection.Insert(user1);
            }
        }
    }
}
