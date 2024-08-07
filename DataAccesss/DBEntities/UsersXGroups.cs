namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("params.UsersXGroups")]
    public partial class UsersXGroups
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int GroupID { get; set; }

        public bool? Enable { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Users Users { get; set; }
    }
}
