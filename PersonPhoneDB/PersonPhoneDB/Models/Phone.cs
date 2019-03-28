using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonPhoneDB.Models
{
    public partial class Phone
    {
        public string Type { get; set; }
        [Key]
        [StringLength(50)]
        public string Number { get; set; }
        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Phone")]
        public virtual Person Person { get; set; }
    }
}