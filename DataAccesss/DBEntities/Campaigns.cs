namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmp.Campaigns")]
    public partial class Campaigns
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campaigns()
        {
            CampaignPool = new HashSet<CampaignPool>();
            CampaignWaves = new HashSet<CampaignWaves>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string CampaignName { get; set; }

        public int CampaignType { get; set; }

        [StringLength(100)]
        public string CampaignClosingReason { get; set; }

        public bool ActiveFlag { get; set; }

        [StringLength(50)]
        public string InsertedUser { get; set; }

        public DateTime? InsertedDate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignPool> CampaignPool { get; set; }

        public virtual CampaignType CampaignType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignWaves> CampaignWaves { get; set; }
    }
}
