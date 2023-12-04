using LotoApp.Models.Enums;

namespace LotoApp.Models.ViewModels
{
    public class WinnerViewModel : TicketNumbers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Prize Prize { get; set; }
        public int SessionId { get; set; }

    }
}
