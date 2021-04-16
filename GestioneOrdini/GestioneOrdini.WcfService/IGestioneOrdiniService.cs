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
    public interface IGestioneOrdiniService
    {
        //Inserisco tutti i servizi che voglio rendere disponibili al client
        [OperationContract]
        bool CreaCliente(Cliente cliente);

        [OperationContract]
        bool CreaOrdine(Ordine ordine, Cliente cliente);

        [OperationContract]
        bool EliminaCliente(int id);

        [OperationContract]
        bool ElimanOrdine(int id);

        [OperationContract]
        bool ModificaCliente(Cliente cliente);

        [OperationContract]
        bool ModificaOrdine(Ordine ordine);

        [OperationContract]
        List<Cliente> GetClienti();

        [OperationContract]
        List<Ordine> GetOrdini();

        [OperationContract]
        Cliente GetCliente(int id);

        [OperationContract]
        Ordine GetOrdine(int id);




    }

}
