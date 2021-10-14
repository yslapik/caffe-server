using System;
using System.ComponentModel.DataAnnotations;

namespace caffeServer.Models
{
    public abstract class BaseModel: IEquatable<BaseModel> 
    {
        [Required] 
        public Guid Id { get; set; }

        public bool Equals(BaseModel other)
        {
            return other != null && Id == other.Id;
        }

        public override bool Equals(object obj) =>  Equals(obj as BaseModel);
        public override int GetHashCode() => Id.GetHashCode();
    }
}