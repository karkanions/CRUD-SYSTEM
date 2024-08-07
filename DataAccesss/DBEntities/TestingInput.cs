namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test.TestingInput")]
    public partial class TestingInput
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Test1 { get; set; }

        public int? Test2 { get; set; }

        [StringLength(50)]
        public string InsertedUser { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? InsertedDate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
