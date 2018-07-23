using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAgenda.Models
{
    public class AppAgendaContext : DbContext
    {
        public AppAgendaContext(DbContextOptions<AppAgendaContext> options ) : base( options )
        {
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
