namespace MtOMAttribute
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rel8
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IF5 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID6 { get; set; }

        [Required]
        [StringLength(1)]
        public string TypeOfJoin { get; set; }

        public virtual Entity5 Entity5 { get; set; }

        public virtual Entity6 Entity6 { get; set; }
    }
}
