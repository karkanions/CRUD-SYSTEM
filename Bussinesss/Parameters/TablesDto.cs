using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Parameters
{
    public class TablesDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }
        public Type ClassTypeBussiness { get; set; }
        public Type ClassTypeDataBase { get; set; }
        public Type ClassTypeBussinessList { get; set; }
        public Type ClassTypeDataBaseList { get; set; }
        public List<ColumnsDto> TableColumns { get; set; }
        public int OrderID { get; set; }
        public bool? Paggination { get; set; }
        public Int16? PageSize { get; set; }
    }
}
