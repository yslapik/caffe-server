using System;
using System.ComponentModel.DataAnnotations;

namespace caffeServer.Models
{
    public class DailyResidues : BaseModel
    {
        [Required] 
        public Guid ResiduesId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        
    }
}