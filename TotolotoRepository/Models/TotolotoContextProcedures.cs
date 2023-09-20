﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using TotolotoRepository.Models;

namespace TotolotoRepository.Models
{
    public partial class TotolotoContext
    {
        private ITotolotoContextProcedures _procedures;

        public virtual ITotolotoContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new TotolotoContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ITotolotoContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
        }
    }

    public partial class TotolotoContextProcedures : ITotolotoContextProcedures
    {
        private readonly TotolotoContext _context;

        public TotolotoContextProcedures(TotolotoContext context)
        {
            _context = context;
        }
    }
}