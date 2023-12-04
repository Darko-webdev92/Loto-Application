using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.Entities
{ 
    public class Winner : TicketNumbers
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Prize { get; set; }

        public int SessionId { get; set; }

    }
}
