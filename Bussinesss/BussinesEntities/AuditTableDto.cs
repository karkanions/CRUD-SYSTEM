using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BussinesEntities
{
    class AuditTableDto
    {
        public int ID { get; set; }
        public string TableName { get; set; }

        public int ReferenceID { get; set; }

        public string OriginalValues { get; set; }

        public string CurrentValues { get; set; }

        public string ChangedValues { get; set; }

        public byte ModificationType { get; set; }

        public DateTime ModificationDateTime { get; set; }
        public string UserName { get; set; }
        public string Validate()
        {
            //na to pernai se mia lista me strings to diaforo tou null
            return null;
        }

    }
}
