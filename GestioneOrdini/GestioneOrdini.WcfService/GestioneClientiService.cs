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
    public class GestioneClientiService : IGestioneClientiService
    {
        //Implemento i servizi richiamando le operazioni CRUD implementate nei repository
        private IRepositoryCliente repoClienti = new RepositoryCliente();

        public bool CreaCliente(Cliente cliente)
        {
            return repoClienti.Create(cliente);
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

        public bool ModificaCliente(int id, Cliente cliente)
        {
            Cliente cliente1 = repoClienti.GetByID(id);
            cliente1.CodiceCliente = cliente.CodiceCliente;
            cliente1.Cognome = cliente.Cognome;
            cliente1.Nome = cliente.Nome;
            return repoClienti.Update(cliente1);
        }

    }
}
