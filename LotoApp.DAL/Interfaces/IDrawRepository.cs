using LotoApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DAL.Interfaces
{
    public interface IDrawRepository
    {
        Task<IEnumerable<Draw>> GetAll();

        Task<Draw> GetLast();
    }
}
