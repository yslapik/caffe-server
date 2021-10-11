using System;

namespace caffeServer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Positions
    {
        [Required] 
        public Guid Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public float Price { get; set; }
    }
}