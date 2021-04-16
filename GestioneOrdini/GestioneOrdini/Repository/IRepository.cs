using GestioneOrdini.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.Repository
{
    //Interfaccia utilizzata per dichiarare i metodi crud, comuni a tutte le entità
    //Può essere implementata solo utilizzato un tipo che implementa l'interfaccia IEntity
    public interface IRepository<T> where T : IEntity
    {
        //Operazioni CRUD
        T GetByID(int id);
        List<T> GetAll();
        bool Delete(int id);
        bool Create(T item);
        bool Update(T item);
    }
}
