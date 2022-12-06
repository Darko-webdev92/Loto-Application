using LotoApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Services.Interfaces
{
    public interface IGameService
    {

        GameManagerResponse EnterTicket(Ticket model, string userId);
    }
}
