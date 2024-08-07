namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("params.AuditTable")]
    public partial class AuditTable
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        public int ReferenceID { get; set; }

        public string OriginalValues { get; set; }

        public string CurrentValues { get; set; }

        public string ChangedValues { get; set; }

        public byte ModificationType { get; set; }

        public DateTime ModificationDateTime { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }
    }
}
