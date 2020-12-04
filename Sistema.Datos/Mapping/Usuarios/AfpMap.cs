using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class AfpMap : IEntityTypeConfiguration<Afp>
    {
        public void Configure(EntityTypeBuilder<Afp> builder)
        {
            builder.ToTable("REH010006")
             .HasKey(ca => ca.id_afp);
           
        }
    }
}
