using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppTest.Tables
{
    public class Coordinate
    {
        [PrimaryKey]
        [AutoIncrement]
        public Guid Id { get; set; }

        public double? StartLatitude { get; set; }
        public double? StartLongitude { get; set; }

        public double? FinishLatitude { get; set; }
        public double? FinishLongitude { get; set; }

        public DateTime Time { get; set; }
    }
}
