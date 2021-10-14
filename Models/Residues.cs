using System;
using System.ComponentModel.DataAnnotations;

namespace caffeServer.Models
{
    public class Residues: BaseModel
    {
        [Required] 
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int TotalAmount { get; set; } 
        public int DefectAmount { get; set; }
    }
}