﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotolotoRepository.Models;

namespace TotolotoRepository
{
    public interface ITotolotoContextFactory
    {
        TotolotoContext CreateDbContext();
        void GenerateScripts();
    }
}
