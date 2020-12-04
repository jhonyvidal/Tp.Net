using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("REH010011")
             .HasKey(ca => ca.id_dependente);

        }
    }
}
