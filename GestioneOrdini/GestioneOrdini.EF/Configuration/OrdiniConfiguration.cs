using GestioneOrdini.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini.EF.Configuration
{
    //Le configurazioni delle tabelle le metto separate dal context
    public class OrdiniConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            //Chiave primaria
            builder
                .HasKey(o => o.ID);

            builder
                .Property(o => o.DataOrdine)
                .IsRequired(); //non può essere nullo

            builder
                .Property(o => o.CodiceProdotto)
                .HasMaxLength(100) //Imposta la lunghezza massima
                .IsRequired();

            builder
                .Property(o => o.CodiceOrdine)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(o => o.Importo)
                .IsRequired();

            //Relazioni:
            //Un ordine può avere un solo cliente
            //Un cliente può avere più ordini
            builder
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordini);

        }
    }
}
