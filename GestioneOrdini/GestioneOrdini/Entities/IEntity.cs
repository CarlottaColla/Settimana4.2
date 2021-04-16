using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.Entities
{
    //Interfaccia comune a tutte le entità
    public interface IEntity
    {
        int ID { get; set; }
    }
}
