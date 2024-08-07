using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BussinesEntities
{
    public class TestingInputDto 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Test1 { get; set; }
        public int? Test2 { get; set; }
        public string InsertedUser { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string LastUpdateUser { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Validate()
        {
            //na to pernai se mia lista me strings to diaforo tou null
            return null;
        }
    }
}
