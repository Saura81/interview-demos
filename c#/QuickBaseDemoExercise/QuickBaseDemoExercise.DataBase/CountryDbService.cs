﻿using QuickBaseDemoExercise.Domain;
using QuickBaseDemoExercise.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.DataBase
{
    public class CountryDbService : ICountrySourceService
    {
        private int _order = 1;
        public int Order
        {
            get { return _order; }
        }

        public Task<List<Country>> GetCountries()
        {
            throw new NotImplementedException();
        }
    }
}
