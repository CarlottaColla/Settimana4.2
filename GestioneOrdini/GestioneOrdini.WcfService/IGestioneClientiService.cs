using GestioneOrdini.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestioneOrdini.WcfService
{
    [ServiceContract]
    public interface IGestioneClientiService
    {
        //Inserisco tutti i servizi che voglio rendere disponibili al client
        [OperationContract]
        bool CreaCliente(Cliente cliente);

        [OperationContract]
        bool EliminaCliente(int id);

        [OperationContract]
        bool ModificaCliente(int id, Cliente cliente);

        [OperationContract]
        List<Cliente> GetClienti();

        [OperationContract]
        Cliente GetCliente(int id);
    }

}
