using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Requisiciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Requisiciones
{
    public class RequisicionMap : IEntityTypeConfiguration<Requisicion>
    {
        public void Configure(EntityTypeBuilder<Requisicion> builder)
        {
            builder.ToTable("RQS010001")
               .HasKey(u => u.idrequisicion);

        }

    }
}