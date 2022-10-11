using Proj_EF_Agenda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_Agenda.Context
{
    internal class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
