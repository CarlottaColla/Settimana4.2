using GestioneOrdini.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.Repository
{
    //Sostituisco il generico con Cliente
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        //Qui inserisco le operazioni relative solo a questa classe
    }
}
