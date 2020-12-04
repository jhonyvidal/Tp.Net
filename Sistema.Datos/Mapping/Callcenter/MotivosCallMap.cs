using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Motivo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Motivo
{
    public class MotivosCallMap : IEntityTypeConfiguration<MotivosCall>
    {
        public void Configure(EntityTypeBuilder<MotivosCall> builder)
        {
            builder.ToTable("CALL010003")
               .HasKey(c => c.idmotivo);
            
        }
    }
}
