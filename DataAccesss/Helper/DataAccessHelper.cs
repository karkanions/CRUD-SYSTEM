using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{

    public class PaginatedStatus
    {
        public static PaginatedStatus paginatedStatus = new PaginatedStatus();

        public bool usePagination = false;
        public int pageNumber = 0;
        public int pageSize = 0;
        public int totalRows = 0;
        public string orderByColumn;
        public Enums.SortDirection orderByDirection = Enums.SortDirection.OrderBy;
        public int GetNumberOfPages()
        {
            var i = Math.Round((Convert.ToDouble(totalRows)) / Convert.ToDouble(pageSize) , MidpointRounding.AwayFromZero);
            return Convert.ToInt32(i);
        }
    }
}
