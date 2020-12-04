using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sistema.Datos.Mapping.Usuarios
{
    public class PaginaMap : IEntityTypeConfiguration<Pagina>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pagina> builder)
        {
            builder.ToTable("TEC010009")
               .HasKey(r => r.id_pagina);
        }
    }
}
