using GestioneOrdini.EF.Configuration;
using GestioneOrdini.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.EF.Context
{
  
    public class GestioneOrdiniContext : DbContext
    {
        //Due costruttori: uno vuoto, uno con options che richiamano quello di base
        public GestioneOrdiniContext () : base() { }
        public GestioneOrdiniContext (DbContextOptions<GestioneOrdiniContext> options) : base (options) { }

        //Stringa di connessione
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; Initial Catalog = GestioneOrdiniEF; Server = .\SQLEXPRESS");
        }

        //Tabelle del database
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Cliente> Clienti { get; set; }

        //Relazioni e creazioni delle tabelle
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Richiamo le configurazioni delle tabella
            builder.ApplyConfiguration<Ordine>(new OrdiniConfiguration());
            builder.ApplyConfiguration<Cliente>(new ClientiConfiguration());
        }

        //Creo il database con le migration:
        //Imposto come progetto di startup e Default GestioneOrdini.EF
        //Utilizzo i comandi: Add-Migration Initial e Update-Database
    }
}
