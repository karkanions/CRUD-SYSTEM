using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BussinesEntities
{
    public class CampaignsDto
    {

        public int ID { get; set; }

        public string CampaignName { get; set; }

        public int CampaignType { get; set; }

        public string CampaignClosingReason { get; set; }

        public bool ActiveFlag { get; set; }

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
