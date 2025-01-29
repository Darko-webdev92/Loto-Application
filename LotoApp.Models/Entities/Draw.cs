using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.Entities
{
    public class Draw : TicketNumbers
    {
        [Key]
        public int Id { get; set; }
        public DateTime? StartSession { get; set; } = DateTime.Now;
        public DateTime? EndSession { get; set; }
        public bool IsSessionActive { get; set; }
    }
}
