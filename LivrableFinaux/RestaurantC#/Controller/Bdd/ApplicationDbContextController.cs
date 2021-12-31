using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectResto.Controllers
{
    using ProjectResto.Models.BDD;
    class ApplicationDbContextController
    {
        private readonly ApplicationDbContext _context;
        public ApplicationDbContextController()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
                .Options;

            _context = new ApplicationDbContext(contextOptions);
        }

    }
}
