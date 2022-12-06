using LotoApp.DAL;
using LotoApp.DomainModels;
using LotoApp.InterfaceModels;
using LotoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _appDbContext;

        public GameService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //public void EnterTicket(Ticket model, string userId)

        public GameManagerResponse EnterTicket(Ticket model, string userId)
        {
            var session = _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();
            if(session != null)
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
                        Console.WriteLine($"{prop.Name}: {prop.GetValue(model, null)}");
                        Console.WriteLine(prop.GetValue(model, null).GetType());
                    }

                    var res = nums.Distinct().Count() == nums.Length;
                    if (res)
                    {
                        TicketDto ticket = new TicketDto
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

                        _appDbContext.Tickets.Add(ticket);
                        _appDbContext.SaveChanges();
                        return new GameManagerResponse
                        {
                            Message = "Sucessfully added ticked",
                        };
                    }
                    else
                    {
                        throw new Exception("Numbers must be different");
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
