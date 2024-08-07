using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BussinesEntities
{
    public class CampaignWavesDto
    {
        
        
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            //public CampaignWaves()
            //{
            //    CampaignPool = new HashSet<CampaignPool>();
            //}

            public int ID { get; set; }

            public int? CampaignId { get; set; }

            public string WaveName { get; set; }

            public DateTime? WaveStartDate { get; set; }

            public DateTime? WaveEndDate { get; set; }

            public string WaveClosingReason { get; set; }

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

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CampaignPool> CampaignPool { get; set; }

        //public virtual Campaigns Campaigns { get; set; }

    }
}
