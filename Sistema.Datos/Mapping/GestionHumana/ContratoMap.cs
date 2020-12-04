using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.GestionHumnana;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.GestionHumana
{
    public class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("REH010036")
             .HasKey(ca => ca.id_contrato);
           
        }
    }
}
