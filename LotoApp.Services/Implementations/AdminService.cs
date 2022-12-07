using LotoApp.DAL;
using LotoApp.DomainModels;
using LotoApp.InterfaceModels;
using LotoApp.InterfaceModels.Enums;
using LotoApp.Mappers;
using LotoApp.Models;
using LotoApp.Services.Interfaces;

namespace LotoApp.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _appDbContext;

        public AdminService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void StartSession()
        {
            var draws = _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();

            if (draws != null)
            {
                if (draws.IsSessionActive == true)
                {
                    throw new Exception("One session is already active");
                }
            }

            var model = new Draw
            {
                StartSession = DateTime.Now,
                IsSessionActive = true,
            };
            _appDbContext.Draws.Add(model);
            _appDbContext.SaveChanges();
        }

        public GameManagerResponse CheckSession()
        {
            var session = _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();
            if (session != null)
            {
                if (session.IsSessionActive == true)
                {
                    return new GameManagerResponse
                    {
                        Message = "There is an active session",
                        IsActive = true,

                    };
                }
            }
            return new GameManagerResponse
            {
                Message = "There is no active session",
                IsActive = false,
            };
        }
        public void EndSession()
        {

            var session = _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();
            if (session != null)
            {
                if (session.IsSessionActive)
                {
                    session.IsSessionActive = false;
                    session.EndSession = DateTime.Now;

                    _appDbContext.Draws.Update(session);
                    _appDbContext.SaveChanges();
                }
                else
                {
                    var message = new GameManagerResponse
                    {
                        Message = "There is no active session",
                        IsActive = false,
                    };
                    throw new Exception(message.Message);
                }
            }

        }

        public List<Winner> StartDraw()
        {
            //int[] nums = null;
            List<Winner> winners = new List<Winner>();

            #region comment
            //var draws = _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();
            //if (draws != null)
            //{
            //    if (draws.IsSessionActive == true)
            //    {
            //        draws.IsSessionActive = false;
            //        nums = RandomArray();
            //        draws.EndSession = DateTime.Now;
            //        draws.Number_1 = nums[0];
            //        draws.Number_2 = nums[1];
            //        draws.Number_3 = nums[2];
            //        draws.Number_4 = nums[3];
            //        draws.Number_5 = nums[4];
            //        draws.Number_6 = nums[5];
            //        draws.Number_7 = nums[6];
            //        _appDbContext.Draws.Update(draws);
            //        _appDbContext.SaveChanges();
            //    }
            //}
            #endregion
            DrawnNumbers drawnNumbers = DrawNumbers();

            var tickets = _appDbContext.Tickets.Where(x => x.TicketPurchased >= drawnNumbers.StartSession && x.TicketPurchased <= drawnNumbers.EndSession).ToList();

            winners = WinningTickets(tickets, drawnNumbers);

            //var draws = _appDbContext.Draws.Count();

            StartSession();

            #region comment
            //if (data != null)
            //{
            //    foreach (var item in data)
            //    {
            //        int[] userNums = new int[7];

            //        userNums[0] = item.Number_1;
            //        userNums[1] = item.Number_2;
            //        userNums[2] = item.Number_3;
            //        userNums[3] = item.Number_4;
            //        userNums[4] = item.Number_5;
            //        userNums[5] = item.Number_6;
            //        userNums[6] = item.Number_7;


            //        int guessedNumbers = 0;
            //        for (int i = 0; i < drawnNumbers.Nums.Length; i++)
            //        {
            //            if (drawnNumbers.Nums[i] == userNums[0] ||
            //               drawnNumbers.Nums[i] == userNums[1] ||
            //               drawnNumbers.Nums[i] == userNums[2] ||
            //               drawnNumbers.Nums[i] == userNums[3] ||
            //               drawnNumbers.Nums[i] == userNums[4] ||
            //               drawnNumbers.Nums[i] == userNums[5] ||
            //               drawnNumbers.Nums[i] == userNums[6]
            //               )
            //            {
            //                guessedNumbers++;
            //            }
            //        }

            //        if (guessedNumbers >= 3)
            //        {
            //            var user = _appDbContext.Users.Where(x => x.Id == item.UserId).FirstOrDefault();
            //            if (user != null)
            //            {
            //                var winner = new Winner
            //                {
            //                    FirstName = user.FirstName,
            //                    LastName = user.LastName,
            //                    Prize = guessedNumbers,
            //                    Number_1 = drawnNumbers.Nums[0],
            //                    Number_2 = drawnNumbers.Nums[1],
            //                    Number_3 = drawnNumbers.Nums[2],
            //                    Number_4 = drawnNumbers.Nums[3],
            //                    Number_5 = drawnNumbers.Nums[4],
            //                    Number_6 = drawnNumbers.Nums[5],
            //                    Number_7 = drawnNumbers.Nums[6],
            //                };
            //                winners.Add(winner);
            //            }
            //        }
            //    }
            //}

            #endregion

            return winners;
        }

        public int[] RandomArray()
        {
            int[] nums = new int[7];
            var rand = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                bool exist = true;//we create a boolean is random number exist and start with true for while loop
                while (exist)
                {
                    exist = false;//we change it because until we didn't see the same value on array, we accept as non-exist.
                    int x = rand.Next(1, 37) + 1;

                    for (int k = 0; k < i; k++)
                    {//we check everynumber until "i" we come.
                        if (x == nums[k])
                        {//if exist we said same value exist
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {//if same value not exist we save it in our array
                        nums[i] = x;
                    }
                }
            }

            return nums;
        }
        public DrawnNumbers DrawNumbers()
        {
            int[] nums = null;

            var draw = _appDbContext.Draws.OrderBy(x => x.Id).LastOrDefault();
            if (draw != null)
            {
                if (draw.IsSessionActive == true)
                {
                    draw.IsSessionActive = false;
                    nums = RandomArray();
                    draw.EndSession = DateTime.Now;
                    draw.Number_1 = nums[0];
                    draw.Number_2 = nums[1];
                    draw.Number_3 = nums[2];
                    draw.Number_4 = nums[3];
                    draw.Number_5 = nums[4];
                    draw.Number_6 = nums[5];
                    draw.Number_7 = nums[6];

                    _appDbContext.Draws.Update(draw);
                    _appDbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The Session must be active");
                }
            }
            //return nums;
            return new DrawnNumbers
            {
                EndSession = draw.EndSession,
                StartSession = draw.StartSession,
                Nums = nums, 
            };
        }

        public List<Winner> WinningTickets(List<TicketDto> ticket, DrawnNumbers drawnNumbers)
        {
            List<Winner> winners = new List<Winner>();
            List<WinnerDto> winnerDtos = new List<WinnerDto>();

            if (ticket != null)
            {
                foreach (var item in ticket)
                {
                    int[] userNums = new int[7];

                    userNums[0] = item.Number_1;
                    userNums[1] = item.Number_2;
                    userNums[2] = item.Number_3;
                    userNums[3] = item.Number_4;
                    userNums[4] = item.Number_5;
                    userNums[5] = item.Number_6;
                    userNums[6] = item.Number_7;


                    int guessedNumbers = 0;
                    for (int i = 0; i < drawnNumbers.Nums.Length; i++)
                    {
                        if (drawnNumbers.Nums[i] == userNums[0] ||
                           drawnNumbers.Nums[i] == userNums[1] ||
                           drawnNumbers.Nums[i] == userNums[2] ||
                           drawnNumbers.Nums[i] == userNums[3] ||
                           drawnNumbers.Nums[i] == userNums[4] ||
                           drawnNumbers.Nums[i] == userNums[5] ||
                           drawnNumbers.Nums[i] == userNums[6]
                           )
                        {
                            guessedNumbers++;
                        }
                    }

                    if (guessedNumbers >= 3)
                    {
                        var user = _appDbContext.Users.Where(x => x.Id == item.UserId).FirstOrDefault();
                        if (user != null)
                        {
                            var winner = new Winner
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Prize = (Prize)guessedNumbers,

                                Number_1 = userNums[0],
                                Number_2 = userNums[1],
                                Number_3 = userNums[2],
                                Number_4 = userNums[3],
                                Number_5 = userNums[4],
                                Number_6 = userNums[5],
                                Number_7 = userNums[6],


                                SessionId = _appDbContext.Draws.Count()
                           };
                            winners.Add(winner);
                        }
                    }
                }
            }

            winnerDtos = winners.Select(x => WinnerMapper.ToWinnerDto(x)).ToList();

            //foreach (var item in winners)
            //{
            //    winnerDtos.Add(WinnerMapper.ToWinnerDto(item));
            //}
            _appDbContext.Winners.AddRange(winnerDtos);
            _appDbContext.SaveChanges();

            return winners;
        }


    }
}
