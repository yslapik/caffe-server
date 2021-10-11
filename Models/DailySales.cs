using System;
using System.ComponentModel.DataAnnotations;

namespace caffeServer.Models
{
    public class DailySales
    {
        [Required] 
        public Guid Id { get; set; }
        [Required] 
        public Guid PositionId { get; set; }
        public int DailyAmount { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
    }
}