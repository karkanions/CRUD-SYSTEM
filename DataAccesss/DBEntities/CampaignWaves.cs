namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmp.CampaignWaves")]
    public partial class CampaignWaves
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampaignWaves()
        {
            CampaignPool = new HashSet<CampaignPool>();
        }

        public int ID { get; set; }

        public int? CampaignId { get; set; }

        [StringLength(100)]
        public string WaveName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WaveStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WaveEndDate { get; set; }

        [StringLength(100)]
        public string WaveClosingReason { get; set; }

        public bool ActiveFlag { get; set; }

        [StringLength(50)]
        public string InsertedUser { get; set; }

        public DateTime? InsertedDate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignPool> CampaignPool { get; set; }

        public virtual Campaigns Campaigns { get; set; }
    }
}
