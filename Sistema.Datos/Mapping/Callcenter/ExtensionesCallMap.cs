using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Extension
{
    public class ExtensionCallMap : IEntityTypeConfiguration<ExtensionCall>
    {
        public void Configure(EntityTypeBuilder<ExtensionCall> builder)
        {
            builder.ToTable("CALL010004")
               .HasKey(c => c.idextencion);
            
        }
    }
}
