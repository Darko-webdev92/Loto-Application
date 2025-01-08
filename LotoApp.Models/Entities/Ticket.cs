using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.Entities
{
    public class Ticket : TicketNumbers
    {
        [Key]
        public int Id { get; set; }

        public DateTime TicketPurchased { get; set; } = DateTime.Now;
        public int Session { get; set; }

        //Navigation properties
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
