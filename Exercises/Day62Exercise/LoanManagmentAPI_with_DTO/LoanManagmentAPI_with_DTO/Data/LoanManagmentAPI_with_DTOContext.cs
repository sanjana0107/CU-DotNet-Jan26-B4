using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagmentAPI_with_DTO.Models;

namespace LoanManagmentAPI_with_DTO.Data
{
    public class LoanManagmentAPI_with_DTOContext : DbContext
    {
        public LoanManagmentAPI_with_DTOContext (DbContextOptions<LoanManagmentAPI_with_DTOContext> options)
            : base(options)
        {
        }

        public DbSet<LoanManagmentAPI_with_DTO.Models.Loan> Loan { get; set; } = default!;
    }
}
