using LotoApp.DAL.Interfaces;
using LotoApp.Models;
using LotoApp.Models.Dto;
using LotoApp.Models.Entities;
using LotoApp.Models.Enums;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LotoApp.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IDrawRepository _drawRepository;
        private readonly IWinnerRepository _winnerRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(IAdminRepository adminRepository, IDrawRepository drawRepository, IWinnerRepository winnerRepository, ITicketRepository ticketRepository, UserManager<ApplicationUser> userManager)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            _drawRepository = drawRepository ?? throw new ArgumentNullException(nameof(drawRepository));
            _winnerRepository = winnerRepository ?? throw new ArgumentNullException(nameof(winnerRepository));
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<GameManagerResponse> StartSession()
        {
            var draws = await _drawRepository.GetLastOrDefault();

            if (draws != null)
            {
                if (draws.IsSessionActive == true)
                {
                    return new GameManagerResponse
                    {
                        Message = "There is an active session",
                    };
                }
            }

            var model = new Draw
            {
                StartSession = DateTime.Now,
                IsSessionActive = true,
            };

            await _adminRepository.Create(model);

            return new GameManagerResponse
            {
                Message = "Session is activated",

            };
        }

        public async Task<GameManagerResponse> CheckSession()
        {
            var session = await _drawRepository.GetLastOrDefault();

            if (session != null)
            {
                if (session.IsSessionActive == true)
                {
                    return new GameManagerResponse
                    {
                        Message = "There is an active session",
                    };
                }
            }

            return new GameManagerResponse
            {
                Message = "There is no active session",
            };
        }
        public async Task<GameManagerResponse> EndSession()
        {
            var session = await _drawRepository.GetLastOrDefault();

            if (session != null)
            {
                if (session.IsSessionActive)
                {
                    session.IsSessionActive = false;
                    session.EndSession = DateTime.Now;

                    await _drawRepository.Update(session);
                }

                return new GameManagerResponse
                {
                    Message = "The session is over",
                };
            }

            return new GameManagerResponse
            {
                Message = "There is no active session",
            };
        }

        public async Task<List<WinnerViewModel>> StartDraw()
        {
            List<WinnerViewModel> winners = new List<WinnerViewModel>();

            DrawnNumbers drawnNumbers = await DrawNumbers();

            var alltickets = await _ticketRepository.GetAll();
            var tickets = alltickets.Where(x => x.TicketPurchased >= drawnNumbers.StartSession && x.TicketPurchased <= drawnNumbers.EndSession).ToList();
            winners = await WinningTickets(tickets, drawnNumbers);

            return winners;
        }

        private int[] RandomArray()
        {
            int[] nums = new int[7];
            var rand = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                bool exist = true;//we create a boolean is random number exist and start with true for while loop
                while (exist)
                {
                    exist = false;//we change it because until we didn't see the same value on array, we accept as non-exist.
                    int number = rand.Next(1, 37) + 1;

                    for (int k = 0; k < i; k++)
                    {//we check every number until "i" we come.
                        if (number == nums[k])
                        {//if exist we said same value exist
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {//if same value not exist we save it in our array
                        nums[i] = number;
                    }
                }
            }
            return nums;
        }
        public async Task<DrawnNumbers> DrawNumbers()
        {
            int[] nums = null;

            var draw = await _drawRepository.GetLastOrDefault();

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

                    await _drawRepository.Update(draw);
                }
            }
            return new DrawnNumbers
            {
                EndSession = draw.EndSession,
                StartSession = draw.StartSession,
                Nums = nums,
            };
        }

        private async Task<List<WinnerViewModel>> WinningTickets(List<Ticket> ticket, DrawnNumbers drawnNumbers)
        {
            List<WinnerViewModel> winnersViewModel = new List<WinnerViewModel>();
            List<Winner> winners = new List<Winner>();
            var lastSession = await _drawRepository.GetLastOrDefault();

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
                        var user = await _userManager.FindByIdAsync(item.UserId);
                        if (user != null)
                        {
                            var winner = new WinnerViewModel
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

                                SessionId = lastSession.Id
                            };
                            winnersViewModel.Add(winner);
                        }
                    }
                }
            }

            winners = winnersViewModel.Select(x => WinnerMapper.ToWinnerDto(x)).ToList();

            await _winnerRepository.AddRange(winners);

            return winnersViewModel;
        }
    }
}
