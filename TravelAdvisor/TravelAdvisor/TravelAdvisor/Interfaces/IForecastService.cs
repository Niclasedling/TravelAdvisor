﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Interfaces
{
    public interface IForecastService
    {
        Task<List<Weather>> GetForcast(string cityName);
    }
}
