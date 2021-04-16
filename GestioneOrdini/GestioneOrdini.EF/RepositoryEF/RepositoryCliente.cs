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
    public class RepositoryCliente : IRepositoryCliente
    {
        //Dichiaro la variabile context che utilizzo per implementare i metodi CRUD
        private readonly GestioneOrdiniContext context;
        //Richiama il costruttore con un parametro
        public RepositoryCliente() : this(new GestioneOrdiniContext()) { }
        public RepositoryCliente(GestioneOrdiniContext contex)
        {
            this.context = contex;
        }

        //Implementazione dell'interfaccia
        public bool Create(Cliente item)
        {
            try
            {
                //Se l'elemento passato è nullo va nel catch
                context.Clienti.Add(item);
                context.SaveChanges(); //Salavo le modifiche sul database
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
                Cliente cliente = context.Clienti.Find(id);
                //Se il cliente è nullo va nel catch

                //Se il cliente ha degli ordini li cancello prima di cancellarlo
                if (cliente != null)
                {
                    var ordiniDelCiente = context.Ordini.Where(o => o.Cliente.ID == id).ToList();
                    if (ordiniDelCiente.Count != 0)
                    {
                        foreach (Ordine ordine in ordiniDelCiente)
                        {
                            context.Ordini.Remove(ordine);
                        }
                    }
                }

                context.Clienti.Remove(cliente);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Cliente> GetAll()
        {
            try
            {
                List<Cliente> clienti = context.Clienti.ToList();
                return clienti;
            }
            catch 
            {
                return null;
            }
        }

        public Cliente GetByID(int id)
        {
            try
            {
                Cliente cliente = context.Clienti.Find(id);
                //Se il cliente è nullo ritorna null
                return cliente;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Cliente item)
        {
            try
            {
                if (context.Clienti.Find(item.ID) == null)
                    return false;

                context.Clienti.Update(item);
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
