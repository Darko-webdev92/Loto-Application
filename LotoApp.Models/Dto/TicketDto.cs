using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;

namespace LotoApp.Models.Dto
{
    public static class TicketDto
    {
        public static Ticket ToTicketDto(TicketViewModel ticket, string userId, Draw session)
        {
            return new Ticket
            {
                Number_1 = ticket.Number_1,
                Number_2 = ticket.Number_2,
                Number_3 = ticket.Number_3,
                Number_4 = ticket.Number_4,
                Number_5 = ticket.Number_5,
                Number_6 = ticket.Number_6,
                Number_7 = ticket.Number_7,
                UserId = userId,
                Session = session.Id
            };
        }
    }
}
