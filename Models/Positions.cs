using System;

namespace caffeServer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Positions: IEquatable<Positions>
    {
        [Required] 
        public Guid Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Equals(Positions other)
        {
            return this.Id.Equals(other.Id);
        }
        public override bool Equals(object obj) => Equals(obj as Positions);
        public override int GetHashCode() => Id.GetHashCode();
    }
}