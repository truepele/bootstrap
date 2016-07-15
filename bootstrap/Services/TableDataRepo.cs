using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            List<string[]> dataList;
            if (!string.IsNullOrEmpty(searchText))
            {
                dataList = ConstructData(0, TotalRecords, TotalRecords);
                dataList = FilterDataList(dataList, searchText, isSearchRegex);
                totalrecords = dataList.Count;
                dataList = dataList.Skip(start).Take(length).ToList();
            }
            else
            {
                dataList = ConstructData(start, length, TotalRecords);
                totalrecords = TotalRecords;
            }
            
            return dataList;
        }

        private static List<string[]> FilterDataList(List<string[]> dataList, string searchText, bool isSearchRegex = false)
        {
            dataList = (from iArr in dataList
                where
                    iArr.FirstOrDefault(
                        str =>
                            isSearchRegex
                                ? Regex.IsMatch(str, searchText, RegexOptions.IgnoreCase)
                                : str.IndexOf(searchText, StringComparison.InvariantCultureIgnoreCase) >= 0) != null
                select iArr).ToList();
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