using GestioneOrdini.EF.Context;
using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.EF.RepositoryEF
{
    public class RepositoryOrdini : IRepositoryOrdine
    {
        //Dichiaro la variabile context che utilizzo per implementare i metodi CRUD
        private readonly GestioneOrdiniContext context;
        //Richiama il costruttore con un parametro
        public RepositoryOrdini() : this(new GestioneOrdiniContext()) { }
        public RepositoryOrdini(GestioneOrdiniContext context)
        {
            this.context = context;
        }

        //Implementazione dell'interfaccia
        public bool Create(Ordine item)
        {
            try
            {
                //Se l'ordine è nullo va nel catch
                //Crea sempre un nuovo cliente
                context.Ordini.Add(item);
                context.SaveChanges(); //Riporta le modifiche sul database
                return true;
            }
            catch
            {
                //In caso di qualsiasi errore ritorna false
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Ordine ordine = context.Ordini.Find(id);
                //Se è nullo va nel catch
                context.Ordini.Remove(ordine);
                context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public List<Ordine> GetAll()
        {
            try
            {
                List<Ordine> ordini = context.Ordini.ToList();
                return ordini;
            }
            catch 
            {
                return null;
            }
        }

        public Ordine GetByID(int id)
        {
            try
            {
                //Se non esiste ritorna null
                return context.Ordini.Find(id);
            }
            catch 
            {
                return null;
            }
        }

        public bool Update(Ordine item)
        {
            try
            {
                if (context.Ordini.Find(item.ID) == null)
                    return false;

                if (context.Clienti.Find(item.Cliente.ID) == null)
                    return false;

                context.Ordini.Update(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
