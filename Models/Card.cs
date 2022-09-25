using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ATMDemoWithWPF.Models
{
    [Table("Card")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Transaction_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public long CardNo { get; set; }
       
        public string Transaction_Mode { get; set; }
        public string Account_Type { get; set; }
        public decimal? Ammount { get; set; }
        public int? Pin { get; set; }
    }
}
