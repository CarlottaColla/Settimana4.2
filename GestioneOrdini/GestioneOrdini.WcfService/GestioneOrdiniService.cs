using GestioneOrdini.EF.RepositoryEF;
using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestioneOrdini.WcfService
{
    public class GestioneOrdiniService : IGestioneOrdiniService
    {
        //Implemento i servizi richiamando le operazioni CRUD implementate nei repository
        private IRepositoryCliente repoClienti = new RepositoryCliente();
        private IRepositoryOrdine repoOrdine = new RepositoryOrdini();

        public bool CreaCliente(Cliente cliente)
        {
            return repoClienti.Create(cliente);
        }

        public bool CreaOrdine(Ordine ordine, Cliente cliente)
        {
            //Crea sempre un nuovo cliente
            ordine.Cliente = cliente;
            return repoOrdine.Create(ordine);
        }

        public bool ElimanOrdine(int id)
        {
            return repoOrdine.Delete(id);
        }

        public bool EliminaCliente(int id)
        {
            return repoClienti.Delete(id);
        }

        public Cliente GetCliente(int id)
        {
            return repoClienti.GetByID(id);
        }

        public List<Cliente> GetClienti()
        {
            return repoClienti.GetAll();
        }

        public Ordine GetOrdine(int id)
        {
            return repoOrdine.GetByID(id);
        }

        public List<Ordine> GetOrdini()
        {
            return repoOrdine.GetAll();
        }

        public bool ModificaCliente(Cliente cliente)
        {
            return repoClienti.Update(cliente);
        }

        public bool ModificaOrdine(Ordine ordine)
        {
            return repoOrdine.Update(ordine);
        }
    }
}
