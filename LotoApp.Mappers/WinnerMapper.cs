using LotoApp.DomainModels;
using LotoApp.InterfaceModels;
using LotoApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Mappers
{
    public static class WinnerMapper
    {
        public static WinnerDto ToWinnerDto(Winner winner)
        {
            return new WinnerDto
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

        public static Winner ToWinner(WinnerDto winner)
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
                Prize =   (Prize)winner.Prize,
                SessionId = winner.SessionId
            };
        }
    }
}
