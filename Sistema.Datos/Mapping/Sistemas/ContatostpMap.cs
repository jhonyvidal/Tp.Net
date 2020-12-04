using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Contactostp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Contactostp
{
    public class ContactostpMap : IEntityTypeConfiguration<Contactotp>
    {
        public void Configure(EntityTypeBuilder<Contactotp> builder)
        {
            builder.ToTable("SIS010001")
               .HasKey(u => u.id_contactostp);
            builder.Property(u => u.id_empleado);
            builder.Property(u => u.extension);
            builder.Property(u => u.numero);
            builder.Property(u => u.correo);
            builder.Property(u => u.estado);
        }
    }
}
