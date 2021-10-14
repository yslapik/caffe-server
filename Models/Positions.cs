using System;

namespace caffeServer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Positions: BaseModel
    {
        [Required] 
        public string Name { get; set; }
        public float Price { get; set; }
    }
}