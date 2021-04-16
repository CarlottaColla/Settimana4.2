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
    public class ClientiConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //Chiave primaria
            builder
                .HasKey(c => c.ID);

            builder
                .Property(c => c.Nome)
                .HasMaxLength(100) //Lunghezza massima
                .IsRequired(); //non può essere nullo

            builder
                .Property(c => c.Cognome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(100)
                .IsRequired();

            //Relazioni:
            //Un ordine può avere un solo cliente
            //Un cliente può avere più ordini
            builder
                .HasMany(c => c.Ordini)
                .WithOne(o => o.Cliente);
        }
    }
}
