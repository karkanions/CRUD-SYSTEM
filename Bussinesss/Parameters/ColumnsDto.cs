using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Parameters
{
    public class ColumnsDto
    {
        public int ID { get; set; }
        public int TableID { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public bool Visible { get; set; }
        public bool Freeze { get; set; }
        public bool ReadOnly { get; set; }
        public bool isCombo { get; set; }
        public string ClassTypeComboName { get; set; }
        public string ComboDisplayMember { get; set; }
        public string ComboValueMember { get; set; }
        public Type ClassTypeBussiness { get; set; }
        public Type ClassTypeDataBase { get; set; }
        public Type ClassTypeBussinessList { get; set; }
        public Type ClassTypeDataBaseList { get; set; }

    }
}
