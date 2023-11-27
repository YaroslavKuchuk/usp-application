﻿using Usp.Models;

namespace Usp.App.Logic.Services.Abstractions
{
    public interface ISellingPointService
    {
        Task<List<SellingPointViewModel>> GetSellingPoints();
    }
}
