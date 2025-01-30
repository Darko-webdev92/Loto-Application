using LotoApp.Models.Entities;
using LotoApp.Models.Enums;
using LotoApp.Models.ViewModels;

namespace LotoApp.Models.Dto
{
    public static class WinnerDto
    {
        public static Winner ToWinnerDto(WinnerViewModel winner)
        {
            return new Winner
            {
                FirstName = winner.FirstName,
                LastName = winner.LastName,
                Number_1 = winner.Number_1,
                Number_2 = winner.Number_2,
                Number_3 = winner.Number_3,
                Number_4 = winner.Number_4,
                Number_5 = winner.Number_5,
                Number_6 = winner.Number_6,
                Number_7 = winner.Number_7,
                Prize = (int)winner.Prize,
                SessionId = winner.SessionId,
            };
        }

        public static WinnerViewModel ToWinnerViewModelDto(Winner winner)
        {
            return new WinnerViewModel
            {
                FirstName = winner.FirstName,
                LastName = winner.LastName,
                Number_1 = winner.Number_1,
                Number_2 = winner.Number_2,
                Number_3 = winner.Number_3,
                Number_4 = winner.Number_4,
                Number_5 = winner.Number_5,
                Number_6 = winner.Number_6,
                Number_7 = winner.Number_7,
                Prize =   (Prize)winner.Prize,
                SessionId = winner.SessionId
            };
        }
    }
}
