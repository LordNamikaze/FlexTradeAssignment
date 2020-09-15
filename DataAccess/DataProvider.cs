using System.Collections.Generic;
using Models;


namespace DataAccess
{
    public class DataProvider
    {
        public IEnumerable<SecurityModel> GetSecuritiesList()
        {
            return SecurityInfo.SecurityItems;
        }
    }
}
