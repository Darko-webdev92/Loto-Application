﻿using LotoApp.Models.Entities;

namespace LotoApp.DAL.Interfaces
{
    public interface IAdminRepository
    {
        Task Add(Draw entity);
    }
}