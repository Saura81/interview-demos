﻿using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.DataBase.Repositories
{
    public interface ICountryRepository
    {
        DbSet<Country> Get();

    }
}
