using System;
using System.ComponentModel.DataAnnotations;

namespace caffeServer.Models
{
    public class DailyResidues
    {
        [Required] 
        public Guid Id { get; set; } 
        [Required] 
        public Guid ResiduesId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        
    }
}