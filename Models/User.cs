using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDemoWithWPF.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long? CardNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Pin { get; set; }

        public decimal? Balance { get; set; }
    }
}
