using System;

namespace caffeServer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Positions: BaseModel
    {
        [Required] 
        public string Name { get; set; }
        [Required] 
        public Guid PositionType { get; set; }
        public decimal Price { get; set; }
    }
}