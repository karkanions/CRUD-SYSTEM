namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("params.TableXGroups")]
    public partial class TableXGroups
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int TableID { get; set; }

        public int GroupID { get; set; }

        public bool Enable { get; set; }

        public virtual TableGroups TableGroups { get; set; }

        public virtual Tables Tables { get; set; }
    }
}
