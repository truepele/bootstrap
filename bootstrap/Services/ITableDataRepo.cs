using System.Collections.Generic;

namespace bootstrap.Services
{
    public interface ITableDataRepo
    {
        List<string[]> GetData();
        List<string[]> GetData(int start, int length, string searchText, bool isSearchRegex, out int totalrecords);        
    }
}