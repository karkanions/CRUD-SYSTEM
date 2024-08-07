namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmp.CampaignPool")]
    public partial class CampaignPool
    {
        public int ID { get; set; }

        public int CampaignId { get; set; }

        public int WaveId { get; set; }

        [Required]
        [StringLength(100)]
        public string ReferenceId { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(50)]
        public string InsertedUser { get; set; }

        public DateTime? InsertedDate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public virtual Campaigns Campaigns { get; set; }

        public virtual CampaignWaves CampaignWaves { get; set; }
    }
}
