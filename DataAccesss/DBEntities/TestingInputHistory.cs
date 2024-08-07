namespace DataAccess.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test.TestingInputHistory")]
    public partial class TestingInputHistory
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [StringLength(1)]
        public string Action { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionUserName { get; set; }

        public int RefID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Test1 { get; set; }

        public int? Test2 { get; set; }

        [StringLength(50)]
        public string InsertedUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InsertedDate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
