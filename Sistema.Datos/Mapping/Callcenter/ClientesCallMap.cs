using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Almacen
{
    public class ClientesCallMap : IEntityTypeConfiguration<ClientesCall>
    {
        public void Configure(EntityTypeBuilder<ClientesCall> builder)
        {
            builder.ToTable("CALL010002")
               .HasKey(c => c.idcliente);
            
        }
    }
}
