using System;
using System.ComponentModel.DataAnnotations;

namespace caffeServer.Models
{
    public class DailySales: BaseModel
    {
        [Required] 
        public Guid PositionId { get; set; }
        public int DailyAmount { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
    }
}