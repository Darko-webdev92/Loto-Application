using LotoApp.DAL.Interfaces;
using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using System.Reflection;

namespace LotoApp.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly IDrawRepository _drawRepository;
        private readonly ITicketRepository _ticketRepository;

        public GameService(IDrawRepository drawRepository, ITicketRepository ticketRepository)
        {
            _drawRepository = drawRepository ?? throw new ArgumentNullException(nameof(drawRepository));
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
        }

        public async Task<GameManagerResponse> EnterTicket(TicketViewModel model, string userId)
        {
            var session = await _drawRepository.GetLastOrDefault();
            if (session != null)
            {
                if (session.IsSessionActive)
                {
                    int[] nums = new int[7];
                    int counter = 0;

                    foreach (PropertyInfo prop in model.GetType().GetProperties())
                    {
                        if (prop.GetValue(model, null).GetType() == typeof(System.Int32))
                        {
                            nums[counter] = (int)prop.GetValue(model, null);
                            counter++;
                        }
                    }

                    var res = nums.Distinct().Count() == nums.Length;
                    if (res)
                    {
                        Ticket ticket = new Ticket
                        {
                            Number_1 = nums[0],
                            Number_2 = nums[1],
                            Number_3 = nums[2],
                            Number_4 = nums[3],
                            Number_5 = nums[4],
                            Number_6 = nums[5],
                            Number_7 = nums[6],
                            TicketPurchased = model.TicketPurchased,
                            UserId = userId,
                            Session = session.Id
                        };
                        await _ticketRepository.Create(ticket);

                        return new GameManagerResponse
                        {
                            Message = "Sucessfully added ticked",
                        };
                    }
                    else
                    {
                        return new GameManagerResponse
                        {
                            Message = "Numbers must be different",

                        };
                    }
                }
            }
            return new GameManagerResponse
            {
                Message = "There is no active session"
            };
        }
    }
}
