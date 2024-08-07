namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("params.Columns")]
    public partial class Columns
    {
        public int ID { get; set; }

        public int TableID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Header { get; set; }

        public bool Visible { get; set; }

        public bool Freeze { get; set; }

        public bool ReadOnly { get; set; }

        public bool? isCombo { get; set; }

        [StringLength(50)]
        public string ComboClass { get; set; }

        [StringLength(50)]
        public string ComboDisplay { get; set; }

        [StringLength(50)]
        public string ComboValue { get; set; }

        public virtual Tables Tables { get; set; }
    }
}
