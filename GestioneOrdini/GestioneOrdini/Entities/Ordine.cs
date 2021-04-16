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
    public class Ordine : IEntity
    {
        //L'id non sarà visualizzato dal client perchè è autoincrementale
        public int ID { get; set; }
        //Non sarà visualizzato dal client perchè viene aggiunto in automatico
        public DateTime DataOrdine { get; set; } = DateTime.Now;
        [DataMember]
        public string CodiceOrdine { get; set; }
        [DataMember]
        public string CodiceProdotto { get; set;}
        [DataMember]
        public decimal Importo { get; set; }

        //Relazioni:
        //Un ordine può avere un solo cliente: molti a 1
        public Cliente Cliente { get; set; }
    }
}
