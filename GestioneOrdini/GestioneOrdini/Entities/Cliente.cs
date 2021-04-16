using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.Entities
{
    //Inserisco DataContract e DataMember per indicare quali sono i dati visibili al client, 
    //dovranno essere serialiizzati per poterli inviare/visualizzare tra client e server
    //utilizzando il formato JSON
    [DataContract]
    public class Cliente : IEntity
    {
        //L'id non sarà visualizzato dal client perchè è autoincrementale
        public int ID { get; set; }
        [DataMember]
        public string CodiceCliente { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cognome { get; set; }

        //Relazioni
        //Un cliente può effettuare più ordini: 1 a molti
        public ICollection<Ordine> Ordini { get; set; } = new List<Ordine>();
    }
}
