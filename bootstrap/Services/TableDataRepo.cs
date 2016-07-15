using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bootstrap.Services
{
    public class TableDataRepo : ITableDataRepo
    {
        private static int TotalRecords = 109;

        public List<string[]> GetData()
        {
            var dataList = ConstructData(0, TotalRecords, TotalRecords);

            return dataList;
        }

        public List<string[]> GetData(int start, int length, string searchText, bool isSearchRegex, out int totalrecords)
        {
            totalrecords = TotalRecords;

            var dataList = ConstructData(start, length, totalrecords);

            return dataList;
        }

        private static List<string[]> ConstructData(int start, int length, int totalrecords)
        {
            var dataList = new List<string[]>();

            for (var i = start; i < start + length && i < totalrecords; i++)
            {
                dataList.Add(new string[] { $"FirstName_{i}", $"LastName_{i}", $"Position_{i}", "", "", "" });
            }

            return dataList;
        }
    }
}