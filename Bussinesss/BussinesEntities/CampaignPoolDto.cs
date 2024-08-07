using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BussinesEntities
{
    public partial class CampaignPoolDto
    {
        public int ID { get; set; }
        public int CampaignId { get; set; }

        public int WaveId { get; set; }
        
        public string ReferenceId { get; set; }

        public bool? ActiveFlag { get; set; }

        public string InsertedUser { get; set; }

        public DateTime? InsertedDate { get; set; }

        public string LastUpdateUser { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        //public virtual Campaigns Campaigns { get; set; }

        //public virtual CampaignWaves CampaignWaves { get; set; }

        public string Validate()
        {
           //na to pernai se mia lista me strings to diaforo tou null
            return null;
        }
    }
}
