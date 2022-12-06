using LotoApp.DomainModels;
using LotoApp.InterfaceModels;
using LotoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Services.Interfaces
{
    public interface IAdminService
    {
        void StartSession();
        GameManagerResponse CheckSession();
        void EndSession();
        List<Winner> StartDraw();
        int[] RandomArray();
        DrawnNumbers DrawNumbers();
        List<Winner> WinningTickets(List<TicketDto> ticket, DrawnNumbers drawnNumbers);

    }
}
