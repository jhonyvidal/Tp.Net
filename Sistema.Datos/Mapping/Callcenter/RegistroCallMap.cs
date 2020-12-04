using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Registro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Registro
{
    public class RegistroCallMap : IEntityTypeConfiguration<RegistroCall>
    {
        public void Configure(EntityTypeBuilder<RegistroCall> builder)
        {
            builder.ToTable("CALL010001")
               .HasKey(c => c.idregistro);

            
        }
    }
}
